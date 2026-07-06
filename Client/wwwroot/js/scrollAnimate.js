window.animateTitle = (selector) => {
    const el = document.querySelector(selector);
    if (el) {
        el.classList.remove('title-hidden');
        // Trigger reflow to restart animation if needed
        void el.offsetWidth;
        el.classList.add('title-animate');
    }
};

window.observeElements = (selector, threshold = 0.2) => {
    const elements = document.querySelectorAll(selector);
    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('animate-card');
                entry.target.classList.remove('hide-card');
                observer.unobserve(entry.target);
            }
        });
    }, { threshold });

    elements.forEach(el => observer.observe(el));
};