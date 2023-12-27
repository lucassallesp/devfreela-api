using System;

namespace DevFreela.Infrastructure.Interfaces
{
    public interface IFileStorageService
    {
        void UploadFile(byte[] bytes, string fileName);
    }
}
