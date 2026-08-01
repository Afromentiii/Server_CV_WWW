window.scrollToElement = (elementId) => {
    const element = document.getElementById(elementId);
    if (element) {
        element.scrollIntoView({ behavior: 'smooth', block: 'start' });
    }
};

window.animateTitle = (selector) => {
    const el = document.querySelector(selector);
    if (el) {
        el.classList.remove('title-hidden');
        // Trigger reflow to restart animation if needed
        void el.offsetWidth;
        el.classList.add('title-animate');
    }
};

window.observeElements = (selector, threshold = 0.05) => {
    const elements = document.querySelectorAll(selector);
    if (!elements.length) return;

    const setupObserver = () => {
        const observer = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    entry.target.classList.add('animate-card');
                    entry.target.classList.remove('hide-card');
                    observer.unobserve(entry.target);
                }
            });
        }, { threshold, rootMargin: '120px 0px 80px 0px' });

        elements.forEach(el => observer.observe(el));
    };

    setTimeout(setupObserver, 50);
};

window.setLanguageCookie = (lang) => {
    const d = new Date();
    d.setTime(d.getTime() + (10 * 60 * 1000)); // 10 minutes
    const expires = "expires=" + d.toUTCString();
    document.cookie = "app_language=" + lang + ";" + expires + ";path=/";
};

window.getLanguageCookie = () => {
    const name = "app_language=";
    const decodedCookie = decodeURIComponent(document.cookie);
    const ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
};