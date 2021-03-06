using System;
using System.Collections.Generic;
using System.Text;

namespace SingleAgenda.Dtos.Messages
{
    public class ResultDto
    {

        public int InsertedId { get; set; }
        public bool Success { get; set; }
        public List<string> Messages { get; set; } = new List<string>();

    }
}
