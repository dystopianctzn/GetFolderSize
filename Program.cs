

Console.WriteLine("Введите путь к вашей папке в формате C:\\...\\...");
string folderPath = Console.ReadLine();

Console.WriteLine("Размер папки {0} байт.", DirSize(new DirectoryInfo(@folderPath))); //путь


static long DirSize(DirectoryInfo targetFolder)
{
    long size = 0;

    try
    {
        FileInfo[] files = targetFolder.GetFiles();
        foreach (FileInfo file in files)
            size += file.Length;


        DirectoryInfo[] subdirectories = targetFolder.GetDirectories();
        foreach (DirectoryInfo sub in subdirectories)
            size += DirSize(sub);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Произошла ошибка: " + ex.Message);
    }

    return size;
}
