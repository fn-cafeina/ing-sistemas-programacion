class Carousel {
  constructor(container) {
    this.container = container;
    this.slides = container.querySelectorAll(".carousel-slide");
    this.indicators = container.querySelectorAll(".carousel-indicator");
    this.prevBtn = container.querySelector(".carousel-prev");
    this.nextBtn = container.querySelector(".carousel-next");
    this.currentIndex = 0;
    this.autoPlayInterval = null;

    this.init();
  }

  init() {
    this.showSlide(0);
    this.startAutoPlay();

    this.prevBtn.addEventListener("click", () => this.prev());
    this.nextBtn.addEventListener("click", () => this.next());

    this.indicators.forEach((indicator, index) => {
      indicator.addEventListener("click", () => this.showSlide(index));
    });

    this.container.addEventListener("mouseenter", () => this.stopAutoPlay());
    this.container.addEventListener("mouseleave", () => this.startAutoPlay());
  }

  showSlide(index) {
    this.slides.forEach((slide) =>
      slide.classList.remove("carousel-slide-active")
    );
    this.indicators.forEach((indicator) =>
      indicator.classList.remove("carousel-indicator-active")
    );

    this.slides[index].classList.add("carousel-slide-active");
    this.indicators[index].classList.add("carousel-indicator-active");
    this.currentIndex = index;
  }

  next() {
    const nextIndex = (this.currentIndex + 1) % this.slides.length;
    this.showSlide(nextIndex);
  }

  prev() {
    const prevIndex =
      (this.currentIndex - 1 + this.slides.length) % this.slides.length;
    this.showSlide(prevIndex);
  }

  startAutoPlay() {
    this.autoPlayInterval = setInterval(() => this.next(), 5000);
  }

  stopAutoPlay() {
    if (this.autoPlayInterval) {
      clearInterval(this.autoPlayInterval);
      this.autoPlayInterval = null;
    }
  }
}

class NavigationManager {
  constructor() {
    this.navLinks = document.querySelectorAll(".nav-link");
    this.sections = document.querySelectorAll(".page-section");
    this.init();
  }

  init() {
    this.navLinks.forEach((link) => {
      link.addEventListener("click", (e) => {
        e.preventDefault();
        const target = link.getAttribute("href");
        this.showSection(target);
        history.pushState(null, "", target);
      });
    });

    window.addEventListener("popstate", () => {
      this.showSection(location.hash || "#inicio");
    });

    this.showSection(location.hash || "#inicio");
  }

  showSection(id) {
    this.sections.forEach((sec) => sec.classList.add("hidden"));
    document.querySelector(id).classList.remove("hidden");

    this.navLinks.forEach((l) => l.classList.remove("nav-link-active"));
    document.querySelector(`a[href='${id}']`).classList.add("nav-link-active");
  }
}

class StudentManager {
  constructor() {
    this.form = document.getElementById("student-form");
    this.tbody = document.getElementById("student-table-body");
    this.table = document.getElementById("student-table");
    this.init();
  }

  init() {
    this.form.addEventListener("submit", (e) => this.handleSubmit(e));
    this.table.addEventListener("click", (e) => this.handleDelete(e));
  }

  handleSubmit(e) {
    e.preventDefault();
    const nombre = document.getElementById("nombre").value.trim();
    const apellido = document.getElementById("apellido").value.trim();
    const carrera = document.getElementById("carrera").value;
    const sexo = document.querySelector('input[name="sexo"]:checked');

    if (!nombre || !apellido || !carrera || !sexo) {
      alert("Completa todos los campos.");
      return;
    }

    const row = document.createElement("tr");
    row.innerHTML = `
            <td class='px-6 py-4 text-sm'>${nombre}</td>
            <td class='px-6 py-4 text-sm'>${apellido}</td>
            <td class='px-6 py-4 text-sm'>${carrera}</td>
            <td class='px-6 py-4 text-sm'>${sexo.value}</td>
            <td class='px-6 py-4 text-sm'><button class='delete-btn bg-red-600 hover:bg-red-700 text-white text-xs px-3 py-1 rounded-md'>Eliminar</button></td>
        `;
    this.tbody.prepend(row);
    this.form.reset();
  }

  handleDelete(e) {
    if (e.target.classList.contains("delete-btn")) {
      e.target.closest("tr").remove();
    }
  }
}

document.addEventListener("DOMContentLoaded", () => {
  const carouselContainer = document.querySelector(".carousel-container");
  if (carouselContainer) {
    new Carousel(carouselContainer);
  }

  new NavigationManager();
  new StudentManager();
});
