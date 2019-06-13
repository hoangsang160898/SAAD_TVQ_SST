using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class TheLoaiBUS
    {
        public static List<TheLoaiDTO> loadAll()
        {
            return TheLoaiDAO.loadAll();
        }
        public static List<TheLoaiDTO> loadAllAndConvertToFillCombobox()
        {
            var result = TheLoaiDAO.loadAll();
            result.Insert(0, new TheLoaiDTO(0,"All types"));
            return result;
        }
    }
}
