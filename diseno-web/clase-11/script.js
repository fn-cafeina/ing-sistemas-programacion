document.addEventListener("DOMContentLoaded", () => {
  const estudiantes = [];
  let currentIndex = -1;
  let isEditing = false;

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

    formControls: document.querySelectorAll(
      ".form-container input, .form-container select"
    ),
  };

  const alternarControlesFormulario = (enable) => {
    elements.formControls.forEach((control) => {
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
    if (index === -1 || estudiantes.length === 0) {
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

  const actualizarEstadoBotones = () => {
    const hayEstudiantes = estudiantes.length > 0;

    elements.btnNuevo.disabled = isEditing;
    elements.btnGuardar.disabled = !isEditing;
    elements.btnCancelar.disabled = !isEditing;
    elements.btnEliminar.disabled = isEditing || !hayEstudiantes;

    elements.btnPrimera.disabled = isEditing || currentIndex <= 0;
    elements.btnAnterior.disabled = isEditing || currentIndex <= 0;
    elements.btnSiguiente.disabled =
      isEditing || !hayEstudiantes || currentIndex >= estudiantes.length - 1;
    elements.btnUltima.disabled =
      isEditing || !hayEstudiantes || currentIndex >= estudiantes.length - 1;
  };

  const actualizarUI = () => {
    alternarControlesFormulario(isEditing);
    cargarEstudianteEnFormulario(currentIndex);
    actualizarEstadoBotones();
  };

  const handleNuevo = () => {
    isEditing = true;
    currentIndex = -1;
    limpiarFormulario();
    alternarControlesFormulario(true);
    actualizarEstadoBotones();
    elements.nombre.focus();
  };

  const handleCancelar = () => {
    isEditing = false;
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

      if (currentIndex >= estudiantes.length) {
        currentIndex = estudiantes.length - 1;
      }

      actualizarUI();
      alert("Estudiante eliminado.");
    }
  };

  const handleNavegacion = (action) => {
    if (isEditing) return;

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

    actualizarUI();
  };

  init();
});
