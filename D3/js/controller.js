var dataArray;

const update = () => {
  var res = document.getElementById("d3").value.trim();
  if (res.includes(",")) {
    dataArray = res.split(",").map(Number);
    if (dataArray.length <= 5) {
      mostrar(dataArray);
    } else {
      alert("ingrese maximo 5 datos");
      return 0;
    }
  } else {
    alert("Los numero deben estar separados por coma ,");
    return 0;
  }
};

