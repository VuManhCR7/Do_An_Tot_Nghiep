// Lấy danh sách tất cả các liên kết trong menu
const links = document.querySelectorAll('.menu ul li a');

// Lặp qua từng liên kết và thêm sự kiện click cho chúng
links.forEach(link => {
	link.addEventListener('click', () => {
		// Loại bỏ lớp active của tất cả các liên kết
		links.forEach(link => link.classList.remove('active'));

		// Thêm lớp active vào liên kết được chọn
		link.classList.add('active');
	});
});

