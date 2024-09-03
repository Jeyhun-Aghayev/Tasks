namespace LabTask.Helper
{
    public static class FileManager
    {

        public static string UploadFile(this IFormFile file, string folderName)
        {
            string filname = String.Empty;
            try
            {
                filname = file.FileName.Length > 64 ? file.FileName.Substring(file.FileName.Length - 64, 64) : file.FileName;

                filname = Guid.NewGuid().ToString() + filname;
                string path = folderName + filname;


                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting file: " + ex.Message);
            }
                return filname;

            
            
        }
        public static bool CheckContent(this IFormFile file, string content)
        {
            return file.ContentType.Contains(content);
        }

        public static void RemoveFile(this string filename, string folder)
        {
            string path = folder + filename;
            try
            {
                File.Delete(path);
                Console.WriteLine("File deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting file: " + ex.Message);
            }
        }
    }
}
