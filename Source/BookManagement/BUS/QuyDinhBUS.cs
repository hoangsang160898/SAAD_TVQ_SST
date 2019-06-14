using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class QuyDinhBUS
    {
        public static QuyDinhDTO loadQuyDinh() => QuyDinhDAO.loadQuyDinh();
        public static bool thayDoiQuyDinh(QuyDinhDTO quyDinhMoi) => QuyDinhDAO.thayDoiQuyDinh(quyDinhMoi);
    }
}
