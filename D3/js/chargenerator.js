const mostrar = (dataArray) => {
    d3.select("svg").remove();
    var colorPalette = ["red", "blue", "green", "purple", "orange"];
    var width = 500;
    var height = 700;
    var barHeight = 40;
    var barSpacing = 20; // Espacio entre barras
    var widthScale = d3.scaleLinear().domain([0, 100]).range([0, width]);
    var axis = d3.axisBottom().ticks(5).scale(widthScale);
    
    var canvas = d3
      .select("#imagen")
      .append("svg")
      .attr("width", width)
      .attr("height", height)
      .append("g")
      .attr("transform", "translate(10,10)");
    
   
    canvas
      .selectAll("rect")
      .data(dataArray)
      .enter()
      .append("rect")
      .attr("width", d => widthScale(d))
      .attr("height", barHeight)
      .attr("y", (d, i) => i * (barHeight + barSpacing))
      .attr("fill", (d, i) => colorPalette[i % colorPalette.length]);
    
  
    canvas
      .selectAll("text")
      .data(dataArray)
      .enter()
      .append("text")
      .text(d => d)
      .attr("x", d => widthScale(d) - 10)
      .attr("y", (d, i) => i * (barHeight + barSpacing) + barHeight / 2 + 6)
      .attr("fill", "white")
      .attr("text-anchor", "end")
      .attr("font-size", "20px")
      .attr("font-family", "Arial");
    
  
    const axisYPosition = dataArray.length * (barHeight + barSpacing) - 20;
    canvas
      .append("g")
      .attr("transform", `translate(0, ${axisYPosition})`)
      .call(axis);
  };
  