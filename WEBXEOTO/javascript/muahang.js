
var form = document.getElementById('purchase-form');
form.addEventListener('submit', function(event) {
  event.preventDefault(); // Ngăn chặn gửi form mặc định
  var name = document.getElementById('name').value;
  var phone = document.getElementById('phone').value;
  var email = document.getElementById('email').value;
  var address = document.getElementById('address').value;
  
  // Thực hiện các xử lý dữ liệu hoặc gửi dữ liệu đến máy chủ ở đây
  
  alert('Đơn hàng của bạn đã được thêm vào giỏ');
  form.reset(); // Xóa nội dung của form
  window.location.href = "index.html"; // Điều hướng về trang chủ sau khi mua hàng thành công
});
