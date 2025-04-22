document.addEventListener("DOMContentLoaded", function () {
    const isDark = localStorage.getItem('theme') === 'dark';
    const toggle = document.getElementById('darkModeToggle');

    // Применяем тёмную или светлую тему
    if (isDark) {
        document.body.classList.add('dark-mode');
        document.body.classList.remove('light-theme');
    } else {
        document.body.classList.add('light-theme');
        document.body.classList.remove('dark-mode');
    }

    // Устанавливаем состояние тумблера
    if (toggle) {
        toggle.checked = isDark;

        toggle.addEventListener('change', function () {
            if (this.checked) {
                document.body.classList.add('dark-mode');
                document.body.classList.remove('light-theme');
                localStorage.setItem('theme', 'dark');
            } else {
                document.body.classList.add('light-theme');
                document.body.classList.remove('dark-mode');
                localStorage.setItem('theme', 'light');
            }
        });
    }
});
