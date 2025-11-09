document.addEventListener("DOMContentLoaded", () => {
  const estudiantes = [];
  let currentIndex = -1;
  let isEditing = false;

  let resultadosFiltro = [];
  let currentFiltroIndex = -1;
  let isFiltering = false;

  const elements = {
    nombre: document.getElementById("nombre"),
    apellido: document.getElementById("apellido"),
    carrera: document.getElementById("carrera"),
    masculino: document.getElementById("masculino"),
    femenino: document.getElementById("femenino"),
    egresado: document.getElementById("egresado"),

    btnNuevo: document.getElementById("btnNuevo"),
    btnGuardar: document.getElementById("btnGuardar"),
    btnCancelar: document.getElementById("btnCancelar"),
    btnEliminar: document.getElementById("btnEliminar"),

    btnPrimera: document.getElementById("btnPrimera"),
    btnAnterior: document.getElementById("btnAnterior"),
    btnSiguiente: document.getElementById("btnSiguiente"),
    btnUltima: document.getElementById("btnUltima"),

    filtro: document.getElementById("filtro"),
    btnBuscar: document.getElementById("btnBuscar"),
    btnLimpiarFiltro: document.getElementById("btnLimpiarFiltro"),

    formFields: document.querySelectorAll('[data-field="form"]'),
    filterControls: document.querySelectorAll(
      ".filter-group input, .filter-group button"
    ),
  };

  const alternarControlesFormulario = (enable) => {
    elements.formFields.forEach((control) => {
      control.disabled = !enable;
    });
  };

  const alternarControlesFiltro = (enable) => {
    elements.filterControls.forEach((control) => {
      control.disabled = !enable;
    });
  };

  const limpiarFormulario = () => {
    elements.nombre.value = "";
    elements.apellido.value = "";
    elements.carrera.value = "";
    elements.masculino.checked = false;
    elements.femenino.checked = false;
    elements.egresado.checked = false;
  };

  const cargarEstudianteEnFormulario = (index) => {
    if (index === -1 || estudiantes.length === 0 || !estudiantes[index]) {
      limpiarFormulario();
      return;
    }
    const student = estudiantes[index];
    elements.nombre.value = student.nombre;
    elements.apellido.value = student.apellido;
    elements.carrera.value = student.carrera;
    elements.masculino.checked = student.sexo === "Masculino";
    elements.femenino.checked = student.sexo === "Femenino";
    elements.egresado.checked = student.egresado;
  };

  const resetFiltroState = () => {
    isFiltering = false;
    resultadosFiltro = [];
    currentFiltroIndex = -1;
    elements.filtro.value = "";
  };

  const actualizarEstadoBotones = () => {
    const hayEstudiantes = estudiantes.length > 0;
    const hayResultadosFiltro = resultadosFiltro.length > 0;

    elements.btnNuevo.disabled = isEditing;
    elements.btnGuardar.disabled = !isEditing;
    elements.btnCancelar.disabled = !isEditing;
    elements.btnEliminar.disabled =
      isEditing || !hayEstudiantes || currentIndex === -1;

    if (isFiltering) {
      elements.btnPrimera.disabled = isEditing || currentFiltroIndex <= 0;
      elements.btnAnterior.disabled = isEditing || currentFiltroIndex <= 0;
      elements.btnSiguiente.disabled =
        isEditing || currentFiltroIndex >= resultadosFiltro.length - 1;
      elements.btnUltima.disabled =
        isEditing || currentFiltroIndex >= resultadosFiltro.length - 1;
    } else {
      elements.btnPrimera.disabled = isEditing || currentIndex <= 0;
      elements.btnAnterior.disabled = isEditing || currentIndex <= 0;
      elements.btnSiguiente.disabled =
        isEditing || !hayEstudiantes || currentIndex >= estudiantes.length - 1;
      elements.btnUltima.disabled =
        isEditing || !hayEstudiantes || currentIndex >= estudiantes.length - 1;
    }
  };

  const actualizarUI = () => {
    alternarControlesFormulario(isEditing);
    alternarControlesFiltro(!isEditing);

    cargarEstudianteEnFormulario(currentIndex);

    actualizarEstadoBotones();
  };

  const handleNuevo = () => {
    isEditing = true;
    currentIndex = -1;
    resetFiltroState();
    limpiarFormulario();
    actualizarUI();
    elements.nombre.focus();
  };

  const handleCancelar = () => {
    isEditing = false;
    resetFiltroState();

    if (estudiantes.length > 0) {
      currentIndex = estudiantes.length - 1;
    } else {
      currentIndex = -1;
    }
    actualizarUI();
  };

  const handleGuardar = () => {
    const nombre = elements.nombre.value.trim();
    const apellido = elements.apellido.value.trim();
    const carrera = elements.carrera.value;
    const sexo = elements.masculino.checked
      ? "Masculino"
      : elements.femenino.checked
      ? "Femenino"
      : "";

    if (!nombre || !apellido || !carrera || !sexo) {
      alert(
        "Por favor, completa todos los campos obligatorios (Nombre, Apellido, Carrera, Sexo)."
      );
      return;
    }

    const nuevoEstudiante = {
      nombre,
      apellido,
      carrera,
      sexo,
      egresado: elements.egresado.checked,
    };

    estudiantes.push(nuevoEstudiante);
    currentIndex = estudiantes.length - 1;
    isEditing = false;
    resetFiltroState();
    actualizarUI();
    alert("Estudiante guardado exitosamente.");
  };

  const handleEliminar = () => {
    if (currentIndex === -1 || !estudiantes[currentIndex]) return;

    const student = estudiantes[currentIndex];
    const confirmacion = confirm(
      `¿Estás seguro de que quieres eliminar a ${student.nombre} ${student.apellido}?`
    );

    if (confirmacion) {
      estudiantes.splice(currentIndex, 1);
      resetFiltroState();

      if (currentIndex >= estudiantes.length) {
        currentIndex = estudiantes.length - 1;
      }

      actualizarUI();
      alert("Estudiante eliminado.");
    }
  };

  const handleNavegacion = (action) => {
    if (isEditing) return;

    if (isFiltering) {
      switch (action) {
        case "primera":
          currentFiltroIndex = 0;
          break;
        case "anterior":
          if (currentFiltroIndex > 0) currentFiltroIndex--;
          break;
        case "siguiente":
          if (currentFiltroIndex < resultadosFiltro.length - 1)
            currentFiltroIndex++;
          break;
        case "ultima":
          currentFiltroIndex = resultadosFiltro.length - 1;
          break;
      }
      currentIndex = resultadosFiltro[currentFiltroIndex];
    } else {
      switch (action) {
        case "primera":
          currentIndex = 0;
          break;
        case "anterior":
          if (currentIndex > 0) currentIndex--;
          break;
        case "siguiente":
          if (currentIndex < estudiantes.length - 1) currentIndex++;
          break;
        case "ultima":
          currentIndex = estudiantes.length - 1;
          break;
      }
    }
    actualizarUI();
  };

  const handleBuscar = () => {
    const termino = elements.filtro.value.toLowerCase().trim();
    if (!termino) {
      handleLimpiarFiltro();
      return;
    }

    resetFiltroState();
    isFiltering = true;

    estudiantes.forEach((student, index) => {
      const nombre = student.nombre.toLowerCase();
      const apellido = student.apellido.toLowerCase();
      const carrera = student.carrera.toLowerCase();

      if (
        nombre.includes(termino) ||
        apellido.includes(termino) ||
        carrera.includes(termino)
      ) {
        resultadosFiltro.push(index);
      }
    });

    if (resultadosFiltro.length > 0) {
      currentFiltroIndex = 0;
      currentIndex = resultadosFiltro[currentFiltroIndex];
    } else {
      alert(
        "No se encontraron registros que coincidan con el valor de búsqueda."
      );
      isFiltering = false;
    }
    actualizarUI();
  };

  const handleLimpiarFiltro = () => {
    resetFiltroState();
    if (estudiantes.length > 0) {
      currentIndex = 0;
    } else {
      currentIndex = -1;
    }
    actualizarUI();
  };

  const init = () => {
    elements.btnNuevo.addEventListener("click", handleNuevo);
    elements.btnCancelar.addEventListener("click", handleCancelar);
    elements.btnGuardar.addEventListener("click", handleGuardar);
    elements.btnEliminar.addEventListener("click", handleEliminar);

    elements.btnPrimera.addEventListener("click", () =>
      handleNavegacion("primera")
    );
    elements.btnAnterior.addEventListener("click", () =>
      handleNavegacion("anterior")
    );
    elements.btnSiguiente.addEventListener("click", () =>
      handleNavegacion("siguiente")
    );
    elements.btnUltima.addEventListener("click", () =>
      handleNavegacion("ultima")
    );

    elements.btnBuscar.addEventListener("click", handleBuscar);
    elements.btnLimpiarFiltro.addEventListener("click", handleLimpiarFiltro);
    elements.filtro.addEventListener("keypress", (e) => {
      if (e.key === "Enter") {
        handleBuscar();
      }
    });

    actualizarUI();
  };

  init();
});
