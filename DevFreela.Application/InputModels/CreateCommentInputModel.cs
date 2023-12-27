using System;

namespace DevFreela.Application.InputModels
{
    public class CreateCommentInputModel
    {
        public int IdProject { get; set; }
        public string Content { get; set; }
        public int IdUser { get; set; }
    }
}
