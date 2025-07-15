using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.DTOs
{
    public record BookDTO(string Title, string Author, string ISBN, DateTime PublishedDate);
}
