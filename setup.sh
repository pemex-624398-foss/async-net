#!/usr/bin/env bash

[[ $# -lt 1 ]] && echo "Usage: $(basename "$0") docker | db" && exit 1

TARGET=$(printf '%s' "$1" | awk '{print tolower($0)}')

case "$TARGET" in
  docker)
    declare -a NETWORKS=("async-net")
    
    for NETWORK in "${NETWORKS[@]}"; do
      echo "Creating docker network $NETWORK"
      docker network create "$NETWORK"
    done
    ;;
  
  db)
    PG_CONTAINER="async-net_postgres"
    DB_NAME=foss
    DB_USER=foss
    
    read -r -s -p "Enter password for user $DB_USER: " DB_PASS
    echo
    
    [[ -z "$DB_PASS" ]] && echo "Password for user $DB_USER is required" && exit 1
    
    read -r -s -p "Confirm password for user $DB_USER: " DB_PASS_CONFIRMED
    echo
    
    [[ "$DB_PASS" != "$DB_PASS_CONFIRMED" ]] && echo "Passwords do not match" && exit 1
    
    echo "Creating database $DB_NAME"
    docker exec "$PG_CONTAINER" createdb -U postgres -E UTF8 "$DB_NAME"
    echo
    
    echo "Creating database user $DB_USER"
    docker exec "$PG_CONTAINER" psql -U postgres -c "create role $DB_USER with login password '$DB_PASS'"
    docker exec "$PG_CONTAINER" psql -U postgres -c "grant all privileges on database $DB_NAME to $DB_USER"
    echo
    ;;
  
  *)
    echo "Unsupported setup target: $TARGET"
    exit 1
    ;;
esac
