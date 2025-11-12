class PaletteApp {
  constructor() {
    this.init();
  }

  init() {
    this.setupNavigation();
    this.setupRangeInputs();
    this.setupPaletteGenerator();
    this.setupImageExtractor();
    this.generatePalette();

    setTimeout(() => {
      this.showNotification("¡Bienvenido a Palette Pro!", "success", 2000);
    }, 1000);
  }

  setupNavigation() {
    const navButtons = document.querySelectorAll(".nav-button");

    navButtons.forEach((button) => {
      button.addEventListener("click", (e) => {
        const section = e.currentTarget.getAttribute("data-section");
        this.switchSection(section);
      });
    });
  }

  switchSection(section) {
    document.querySelectorAll(".nav-button").forEach((btn) => {
      btn.classList.remove("active");
    });
    document
      .querySelector(`[data-section="${section}"]`)
      .classList.add("active");

    document.querySelectorAll(".content-section").forEach((sectionEl) => {
      sectionEl.classList.remove("active");
    });
    document.getElementById(section).classList.add("active");
  }

  setupRangeInputs() {
    this.setupRangeInput("color-count", "color-count-value");
    this.setupRangeInput("color-count-extract", "color-count-extract-value");
  }

  setupRangeInput(inputId, valueId) {
    const input = document.getElementById(inputId);
    const value = document.getElementById(valueId);

    if (input && value) {
      input.addEventListener("input", () => {
        value.textContent = input.value;
      });
    }
  }

  setupPaletteGenerator() {
    const baseColorInput = document.getElementById("base-color");
    const baseColorText = document.getElementById("base-color-text");
    const generateBtn = document.getElementById("generate-btn");

    baseColorInput.addEventListener("input", () => {
      baseColorText.value = baseColorInput.value;
    });

    baseColorText.addEventListener("input", () => {
      if (/^#[0-9A-F]{6}$/i.test(baseColorText.value)) {
        baseColorInput.value = baseColorText.value;
      }
    });

    generateBtn.addEventListener("click", () => {
      this.generatePalette();
      this.showNotification("Paleta generada", "success");
    });
  }

  setupImageExtractor() {
    const uploadArea = document.getElementById("upload-area");
    const imageUpload = document.getElementById("image-upload");
    const imagePreviewContainer = document.getElementById(
      "image-preview-container"
    );
    const imagePreview = document.getElementById("image-preview");
    const removeImageBtn = document.getElementById("remove-image");
    const extractBtn = document.getElementById("extract-btn");

    uploadArea.addEventListener("click", () => imageUpload.click());

    this.setupDragAndDrop(uploadArea);

    imageUpload.addEventListener("change", (e) => {
      if (e.target.files.length > 0) {
        this.handleImageFile(e.target.files[0]);
      }
    });

    removeImageBtn.addEventListener("click", () => {
      imagePreviewContainer.classList.add("hidden");
      uploadArea.classList.remove("hidden");
      imagePreview.src = "";
      imageUpload.value = "";
      this.showNotification("Imagen removida", "success");
    });

    extractBtn.addEventListener("click", () => {
      this.extractColorsFromImage();
    });
  }

  setupDragAndDrop(uploadArea) {
    uploadArea.addEventListener("dragover", (e) => {
      e.preventDefault();
      uploadArea.style.borderColor = "hsl(var(--primary))";
      uploadArea.style.backgroundColor = "hsl(var(--accent))";
    });

    uploadArea.addEventListener("dragleave", () => {
      uploadArea.style.borderColor = "hsl(var(--border))";
      uploadArea.style.backgroundColor = "hsl(var(--muted))";
    });

    uploadArea.addEventListener("drop", (e) => {
      e.preventDefault();
      uploadArea.style.borderColor = "hsl(var(--border))";
      uploadArea.style.backgroundColor = "hsl(var(--muted))";

      if (e.dataTransfer.files.length > 0) {
        this.handleImageFile(e.dataTransfer.files[0]);
      }
    });
  }

  handleImageFile(file) {
    if (!file.type.match("image.*")) {
      this.showNotification(
        "Por favor, selecciona un archivo de imagen válido",
        "error"
      );
      return;
    }

    const reader = new FileReader();

    reader.onload = (e) => {
      const imagePreview = document.getElementById("image-preview");
      const uploadArea = document.getElementById("upload-area");
      const imagePreviewContainer = document.getElementById(
        "image-preview-container"
      );

      imagePreview.src = e.target.result;
      uploadArea.classList.add("hidden");
      imagePreviewContainer.classList.remove("hidden");
      this.showNotification("Imagen cargada correctamente", "success");
    };

    reader.readAsDataURL(file);
  }

  showNotification(message, type = "info", duration = 2000) {
    const notification = document.getElementById("notification");
    notification.textContent = message;
    notification.className = `notification-toast ${type} show`;

    setTimeout(() => {
      notification.classList.remove("show");
    }, duration);
  }

  generatePalette() {
    const baseColor = document.getElementById("base-color").value;
    const paletteType = document.getElementById("palette-type").value;
    const colorCount = parseInt(document.getElementById("color-count").value);

    const colors = this.generateColors(baseColor, paletteType, colorCount);
    this.displayPalette(colors, "generated-palette");
  }

  generateColors(baseColor, type, count) {
    const baseHSL = this.hexToHSL(baseColor);
    let colors = [];

    switch (type) {
      case "monochromatic":
        colors = this.generateMonochromatic(baseHSL, count);
        break;
      case "analogous":
        colors = this.generateAnalogous(baseHSL, count);
        break;
      case "complementary":
        colors = this.generateComplementary(baseHSL, count);
        break;
      case "triadic":
        colors = this.generateTriadic(baseHSL, count);
        break;
      case "tetradic":
        colors = this.generateTetradic(baseHSL, count);
        break;
      default:
        colors = this.generateMonochromatic(baseHSL, count);
    }

    return colors.map((hsl) => this.hslToHex(hsl));
  }

  generateMonochromatic(baseHSL, count) {
    const colors = [];
    const step = 100 / (count - 1);

    for (let i = 0; i < count; i++) {
      const lightness = Math.max(5, Math.min(95, baseHSL.l - 30 + step * i));
      colors.push({
        h: baseHSL.h,
        s: baseHSL.s,
        l: lightness,
      });
    }

    return colors;
  }

  generateAnalogous(baseHSL, count) {
    const colors = [];
    const step = 30 / (count - 1);

    for (let i = 0; i < count; i++) {
      const hue = (baseHSL.h - 15 + step * i + 360) % 360;
      colors.push({
        h: hue,
        s: baseHSL.s,
        l: baseHSL.l,
      });
    }

    return colors;
  }

  generateComplementary(baseHSL, count) {
    const colors = [];
    const complementaryHue = (baseHSL.h + 180) % 360;

    for (let i = 0; i < count; i++) {
      const hue = i < count / 2 ? baseHSL.h : complementaryHue;
      const lightness = baseHSL.l + (i % 2 === 0 ? -10 : 10);

      colors.push({
        h: hue,
        s: baseHSL.s,
        l: Math.max(10, Math.min(90, lightness)),
      });
    }

    return colors;
  }

  generateTriadic(baseHSL, count) {
    const colors = [];
    const triadicHue1 = (baseHSL.h + 120) % 360;
    const triadicHue2 = (baseHSL.h + 240) % 360;

    for (let i = 0; i < count; i++) {
      let hue;
      if (i % 3 === 0) hue = baseHSL.h;
      else if (i % 3 === 1) hue = triadicHue1;
      else hue = triadicHue2;

      colors.push({
        h: hue,
        s: baseHSL.s,
        l: baseHSL.l + (i % 2 === 0 ? -5 : 5),
      });
    }

    return colors;
  }

  generateTetradic(baseHSL, count) {
    const colors = [];
    const tetradicHue1 = (baseHSL.h + 90) % 360;
    const tetradicHue2 = (baseHSL.h + 180) % 360;
    const tetradicHue3 = (baseHSL.h + 270) % 360;

    for (let i = 0; i < count; i++) {
      let hue;
      if (i % 4 === 0) hue = baseHSL.h;
      else if (i % 4 === 1) hue = tetradicHue1;
      else if (i % 4 === 2) hue = tetradicHue2;
      else hue = tetradicHue3;

      colors.push({
        h: hue,
        s: baseHSL.s,
        l: baseHSL.l + (i % 2 === 0 ? -5 : 5),
      });
    }

    return colors;
  }

  hexToHSL(hex) {
    let r = 0,
      g = 0,
      b = 0;

    if (hex.length === 4) {
      r = parseInt(hex[1] + hex[1], 16);
      g = parseInt(hex[2] + hex[2], 16);
      b = parseInt(hex[3] + hex[3], 16);
    } else if (hex.length === 7) {
      r = parseInt(hex[1] + hex[2], 16);
      g = parseInt(hex[3] + hex[4], 16);
      b = parseInt(hex[5] + hex[6], 16);
    }

    r /= 255;
    g /= 255;
    b /= 255;

    const max = Math.max(r, g, b);
    const min = Math.min(r, g, b);
    let h,
      s,
      l = (max + min) / 2;

    if (max === min) {
      h = s = 0;
    } else {
      const d = max - min;
      s = l > 0.5 ? d / (2 - max - min) : d / (max + min);

      switch (max) {
        case r:
          h = (g - b) / d + (g < b ? 6 : 0);
          break;
        case g:
          h = (b - r) / d + 2;
          break;
        case b:
          h = (r - g) / d + 4;
          break;
      }

      h /= 6;
    }

    return {
      h: Math.round(h * 360),
      s: Math.round(s * 100),
      l: Math.round(l * 100),
    };
  }

  hslToHex(hsl) {
    const h = hsl.h / 360;
    const s = hsl.s / 100;
    const l = hsl.l / 100;

    let r, g, b;

    if (s === 0) {
      r = g = b = l;
    } else {
      const hue2rgb = (p, q, t) => {
        if (t < 0) t += 1;
        if (t > 1) t -= 1;
        if (t < 1 / 6) return p + (q - p) * 6 * t;
        if (t < 1 / 2) return q;
        if (t < 2 / 3) return p + (q - p) * (2 / 3 - t) * 6;
        return p;
      };

      const q = l < 0.5 ? l * (1 + s) : l + s - l * s;
      const p = 2 * l - q;

      r = hue2rgb(p, q, h + 1 / 3);
      g = hue2rgb(p, q, h);
      b = hue2rgb(p, q, h - 1 / 3);
    }

    const toHex = (x) => {
      const hex = Math.round(x * 255).toString(16);
      return hex.length === 1 ? "0" + hex : hex;
    };

    return `#${toHex(r)}${toHex(g)}${toHex(b)}`;
  }

  hexToRGB(hex) {
    let r = 0,
      g = 0,
      b = 0;

    if (hex.length === 4) {
      r = parseInt(hex[1] + hex[1], 16);
      g = parseInt(hex[2] + hex[2], 16);
      b = parseInt(hex[3] + hex[3], 16);
    } else if (hex.length === 7) {
      r = parseInt(hex[1] + hex[2], 16);
      g = parseInt(hex[3] + hex[4], 16);
      b = parseInt(hex[5] + hex[6], 16);
    }

    return { r, g, b };
  }

  getContrastColor(hexColor) {
    const rgb = this.hexToRGB(hexColor);
    const brightness = (rgb.r * 299 + rgb.g * 587 + rgb.b * 114) / 1000;
    return brightness > 128 ? "#000000" : "#FFFFFF";
  }

  displayPalette(colors, containerId) {
    const container = document.getElementById(containerId);
    container.innerHTML = "";

    colors.forEach((color) => {
      const rgb = this.hexToRGB(color);
      const contrastColor = this.getContrastColor(color);

      const colorCard = document.createElement("div");
      colorCard.className = "color-card";

      colorCard.innerHTML = `
                <div class="color-swatch" style="background-color: ${color};" data-color="${color}">
                    <i class="fas fa-copy" style="color: ${contrastColor};"></i>
                </div>
                <div class="color-info">
                    <div class="color-hex monospace">${color.toUpperCase()}</div>
                    <div class="color-rgb monospace">rgb(${rgb.r}, ${rgb.g}, ${
        rgb.b
      })</div>
                </div>
            `;

      container.appendChild(colorCard);
    });

    setTimeout(() => {
      this.setupColorCopyListeners(containerId);
    }, 100);
  }

  setupColorCopyListeners(containerId) {
    const swatches = document.querySelectorAll(`#${containerId} .color-swatch`);

    swatches.forEach((swatch) => {
      swatch.addEventListener("click", (e) => {
        e.preventDefault();
        this.handleColorCopy(swatch);
      });

      swatch.addEventListener(
        "touchstart",
        () => {
          swatch.style.transform = "scale(0.95)";
        },
        { passive: true }
      );

      swatch.addEventListener(
        "touchend",
        () => {
          swatch.style.transform = "scale(1)";
        },
        { passive: true }
      );
    });
  }

  async handleColorCopy(swatch) {
    const color = swatch.getAttribute("data-color");

    try {
      if (navigator.clipboard && window.isSecureContext) {
        await navigator.clipboard.writeText(color);
      } else {
        await this.fallbackCopyToClipboard(color);
      }

      this.showCopyFeedback(swatch, color);
      this.showNotification(`Copiado: ${color}`, "success", 1500);
    } catch (err) {
      console.error("Error al copiar:", err);
      this.showNotification("Error al copiar el color", "error");
    }
  }

  async fallbackCopyToClipboard(text) {
    return new Promise((resolve, reject) => {
      const textArea = document.createElement("textarea");
      textArea.value = text;
      textArea.style.position = "fixed";
      textArea.style.left = "-999999px";
      textArea.style.top = "-999999px";
      document.body.appendChild(textArea);
      textArea.focus();
      textArea.select();

      try {
        const successful = document.execCommand("copy");
        document.body.removeChild(textArea);
        if (successful) {
          resolve();
        } else {
          reject(new Error("Fallback copy failed"));
        }
      } catch (err) {
        document.body.removeChild(textArea);
        reject(err);
      }
    });
  }

  showCopyFeedback(swatch, color) {
    const icon = swatch.querySelector("i");
    if (!icon) return;

    const originalClass = icon.className;
    icon.className = "fas fa-check";

    setTimeout(() => {
      icon.className = originalClass;
    }, 1000);
  }

  extractColorsFromImage() {
    const image = document.getElementById("image-preview");
    const colorCount = parseInt(
      document.getElementById("color-count-extract").value
    );

    if (!image.src) {
      this.showNotification("Por favor, carga una imagen primero", "error");
      return;
    }

    const colors = this.extractDominantColors(image, colorCount);
    this.displayPalette(colors, "extracted-palette");
    this.showNotification("Colores extraídos", "success");
  }

  extractDominantColors(image, colorCount) {
    const canvas = document.createElement("canvas");
    const ctx = canvas.getContext("2d");

    canvas.width = image.naturalWidth;
    canvas.height = image.naturalHeight;
    ctx.drawImage(image, 0, 0, canvas.width, canvas.height);

    const imageData = ctx.getImageData(0, 0, canvas.width, canvas.height);
    const pixels = imageData.data;

    const sampleSize = 5000;
    const step = Math.max(1, Math.floor(pixels.length / 4 / sampleSize));
    const sampledPixels = [];

    for (let i = 0; i < pixels.length; i += 4 * step) {
      const r = pixels[i];
      const g = pixels[i + 1];
      const b = pixels[i + 2];
      const brightness = (r + g + b) / 3;

      if (brightness > 20 && brightness < 240) {
        sampledPixels.push([r, g, b]);
      }
    }

    const groups = [];
    const threshold = 50;

    sampledPixels.forEach((pixel) => {
      let foundGroup = false;

      for (let group of groups) {
        const [r2, g2, b2] = group.center;
        const distance = Math.sqrt(
          Math.pow(pixel[0] - r2, 2) +
            Math.pow(pixel[1] - g2, 2) +
            Math.pow(pixel[2] - b2, 2)
        );

        if (distance < threshold) {
          group.pixels.push(pixel);
          group.center = [
            (group.center[0] * (group.pixels.length - 1) + pixel[0]) /
              group.pixels.length,
            (group.center[1] * (group.pixels.length - 1) + pixel[1]) /
              group.pixels.length,
            (group.center[2] * (group.pixels.length - 1) + pixel[2]) /
              group.pixels.length,
          ];
          foundGroup = true;
          break;
        }
      }

      if (!foundGroup) {
        groups.push({
          center: [...pixel],
          pixels: [pixel],
        });
      }
    });

    groups.sort((a, b) => b.pixels.length - a.pixels.length);
    const dominantGroups = groups.slice(0, colorCount);

    const colors = dominantGroups.map((group) => {
      const [r, g, b] = group.center.map(Math.round);
      return this.rgbToHex(r, g, b);
    });

    colors.sort((a, b) => {
      const rgbA = this.hexToRGB(a);
      const rgbB = this.hexToRGB(b);
      const lumA = (rgbA.r * 299 + rgbA.g * 587 + rgbA.b * 114) / 1000;
      const lumB = (rgbB.r * 299 + rgbB.g * 587 + rgbB.b * 114) / 1000;
      return lumA - lumB;
    });

    return colors;
  }

  rgbToHex(r, g, b) {
    return (
      "#" +
      (r < 16 ? "0" : "") +
      r.toString(16) +
      (g < 16 ? "0" : "") +
      g.toString(16) +
      (b < 16 ? "0" : "") +
      b.toString(16)
    );
  }
}

document.addEventListener("DOMContentLoaded", () => {
  new PaletteApp();
});
