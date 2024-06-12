using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using API.Common;

namespace API.Entities
{
    public class Orders : BaseModels
    {
        public string UserId { get; set; }
        public Users User { get; set; }

        public ICollection<OrderItems> OrderItem { get; set; }
    }

    //10. Tạo class OrdersController trong thư mục Controllers
    //11. Tạo phương thức thêm mới đơn hàng trong OrdersController
    //12. Tạo phương thức thêm mới chi tiết đơn hàng trong OrdersController
    //13. Tạo phương thức thêm mới sản phẩm trong đơn hàng trong OrdersController
    //14. Tạo phương thức lấy danh sách đơn hàng trong OrdersController
    //15. Tạo phương thức lấy chi tiết đơn hàng trong OrdersController
    //16. Tạo phương thức lấy sản phẩm trong đơn hàng trong OrdersController
    //17. Tạo phương thức cập nhật đơn hàng trong OrdersController
    //18. Tạo phương thức cập nhật chi tiết đơn hàng trong OrdersController
    //19. Tạo phương thức cập nhật sản phẩm trong đơn hàng trong OrdersController
    //20. Tạo phương thức xóa đơn hàng trong OrdersController
    //21. Tạo phương thức xóa chi tiết đơn hàng trong OrdersController
    //22. Tạo phương thức xóa sản phẩm trong đơn hàng trong OrdersController
    //23. Tạo phương thức tìm kiếm đơn hàng trong OrdersController
    //24. Tạo phương thức tìm kiếm chi tiết đơn hàng trong OrdersController
    //25. Tạo phương thức tìm kiếm sản phẩm trong đơn hàng trong OrdersController
    //26. Tạo phương thức thống kê đơn hàng trong OrdersController
    //27. Tạo phương thức thống kê chi tiết đơn hàng trong OrdersController
    //28. Tạo phương thức thống kê sản phẩm trong đơn hàng trong OrdersController
    //29. Tạo phương thức thống kê đơn hàng theo ngày trong OrdersController
    //30. Tạo phương thức thống kê chi tiết đơn hàng theo ngày trong OrdersController
    //31. Tạo phương thức thống kê sản phẩm trong đơn hàng theo ngày trong OrdersController
    //32. Tạo phương thức thống kê đơn hàng theo tháng trong OrdersController
    //33. Tạo phương thức thống kê chi tiết đơn hàng theo tháng trong OrdersController
}