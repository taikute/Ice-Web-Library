using API.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class TestM
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }
    }
}
