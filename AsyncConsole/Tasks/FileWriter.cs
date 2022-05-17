namespace AsyncConsole.Tasks;

public class FileWriter : IDisposable
{
    private readonly FileStream _fileStream;
    private bool _disposed;

    public FileWriter(string filePath)
    {
        Log.WriteLine($"{nameof(FileWriter)}: Constructor invoked");
        _fileStream = File.OpenWrite(filePath);
        Log.WriteLine($"{nameof(FileWriter)}: Inner file stream created");
    }

    ~FileWriter()
    {
        Log.WriteLine($"{nameof(FileWriter)}: Destructor invoked");
        Dispose(false);
    }

    
    public Task WriteLineAsync(string line)
    {
        return Task.Run(() =>
        {
            Log.WriteLine($"Writing line: {line}");
            WriteString(line);
            WriteString(Environment.NewLine);
        });
    }
    
    private void WriteString(string str)
    {
        foreach (var c in str)
        {
            _fileStream.WriteByte((byte) c);
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            Log.WriteLine($"{nameof(FileWriter)}: Flushing inner file stream");
            _fileStream.Flush();
            _fileStream.Dispose();
            Log.WriteLine($"{nameof(FileWriter)}: Inner file stream disposed");
        }

        _disposed = true;
    }
}