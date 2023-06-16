

Console.Write("Введите путь к вашей папке в формате C:\\...\\... ");
string folderPath = Console.ReadLine();

long folderSize = DirSize(new DirectoryInfo(@folderPath));
if (folderSize == 0)
    Console.WriteLine("Папка пустая или файлы в ней ничего не весят");
else
    Console.WriteLine("Размер папки {0} байт.", folderSize);


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
