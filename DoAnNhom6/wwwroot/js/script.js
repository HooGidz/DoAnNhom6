function toggleHeart(heartIcon) {
    heartIcon.classList.toggle('selected'); // Thêm hoặc xóa lớp 'selected' khi nhấn vào
}


document.addEventListener('DOMContentLoaded', function () {
    const formElements = document.querySelectorAll('input, select, textarea'); // Chọn tất cả các trường trong form
    formElements.forEach(element => {
        // Loại trừ trường sao (input[name="star"]) khỏi việc xóa giá trị
        if (element.name !== 'star') {
            element.value = ''; // Đặt giá trị của các trường còn lại là trống
        }
    });
});

const stars = document.querySelectorAll('#star-rating i'); // Các sao trong giao diện
const ratingValue = document.getElementById('rating-value'); // Thẻ hiển thị giá trị đánh giá
const starInput = document.querySelector('input[name="star"]'); // Input ẩn lưu giá trị sao

let selectedRating = 5; // Biến lưu giá trị sao đã chọn
starInput.value = selectedRating;
//ratingValue.textContent = `Bạn đã đánh giá: ${selectedRating} sao`;

// Lặp qua từng sao để gắn sự kiện
stars.forEach(star => {
    // Hiển thị hiệu ứng hover
    star.addEventListener('mouseover', () => {
        const value = star.getAttribute('data-value');
        updateStars(value); // Cập nhật hiệu ứng hover
    });

    // Khi người dùng click chọn sao
    star.addEventListener('click', () => {
        selectedRating = star.getAttribute('data-value'); // Lưu giá trị sao được chọn
        starInput.value = selectedRating; // Gán giá trị sao vào input ẩn
        ratingValue.textContent = `Bạn đã đánh giá: ${selectedRating} sao`;
        setSelectedStars(selectedRating); // Cập nhật màu sao đã chọn
    });

    // Khi người dùng bỏ qua (mouseout)
    star.addEventListener('mouseout', () => {
        updateStars(selectedRating); // Khôi phục màu sắc theo giá trị đã chọn
    });
});

// Cập nhật hiệu ứng màu sao khi hover hoặc click
function updateStars(value) {
    stars.forEach(star => {
        if (star.getAttribute('data-value') <= value) {
            star.style.color = '#FFD43B'; // Màu vàng
        } else {
            star.style.color = '#dcdcdc'; // Màu xám
        }
    });
}

// Cập nhật màu sao đã chọn
function setSelectedStars(value) {
    stars.forEach(star => {
        if (star.getAttribute('data-value') <= value) {
            star.style.color = '#FFD43B';
        } else {
            star.style.color = '#dcdcdc';
        }
    });
}