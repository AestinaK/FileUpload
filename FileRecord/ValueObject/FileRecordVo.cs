namespace FileRecord.ValueObject
{
    public class FileRecordVo
    {

        public FileRecordVo(string parentDirectoryEntity, IFormFile file) { 
               ParentDirectoryIdentity = parentDirectoryEntity;
            File = file;

        }
        public string ParentDirectoryIdentity { get; set; }

        public IFormFile File { get; set; }
    }
}
