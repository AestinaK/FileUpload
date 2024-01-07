using FileRecord.ValueObject;

namespace FileRecord.Helper
{
    public static class FileHelper
    {
        public const string Root = "Content/";

        public static async Task<string> SavePhysicalFileAsync(FileRecordVo recordVo)
        {
            var path = Path.Combine(Root, recordVo.ParentDirectoryIdentity);
            EnsureDirectoryCreated(path);
            var extension = Path.GetExtension(recordVo.File.FileName);
            var encryptedFileName = Guid.NewGuid() + extension;
            var filePath = Path.Combine(path, encryptedFileName);
            await using var stream = new FileStream(filePath, FileMode.Create);
            await recordVo.File.CopyToAsync(stream);
            return encryptedFileName;
        }

        public static string GetFile(string parentDirectoryIdentity, string fileName)
        {
            var path = Path.Combine(Root + parentDirectoryIdentity, fileName);
            return path;
        }

        public static void RemoveFile(string parentDirectoryIdentity, string fileName) {

            var removeFile = Path.Combine(Root,  parentDirectoryIdentity, fileName);
            File.Delete(removeFile);
        
        }

        public static async Task<string> UpdateFileAsync(FileRecordVo vo, string existingFile)
        {
            if (vo.File == null) return default;
            var filePath = Path.Combine("/" + Root + vo.ParentDirectoryIdentity, existingFile);
            if(File.Exists(filePath))
            {
                RemoveFile(vo.ParentDirectoryIdentity, existingFile);
            }
           return await SavePhysicalFileAsync(vo);
        }

        private static void EnsureDirectoryCreated(string rootDirectory)
        {
            if (!Directory.Exists(rootDirectory)) Directory.CreateDirectory(rootDirectory);
        }

    }
}
