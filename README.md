//Como clonar el repositorio....

Primero abrir visual studio
click en Clonar Repositorio
ir al repositorio en github y dar click en boton verde "Code" y copiar el link
en visual pegaremos el link donde dice "Ubicacion del Repositorio"
Listo

//INSTALAR DATABASE ANTES DE CORRER EL PROGRAMA 
ir a la clase "ConexionDB" y cambiar "Server=LAPODEROS" por el nombre de su instancia en SQL o el nombre de su equipo
ejemplo "Server=Nombre de su equipo o instancia"

//Como funciona el Programa......
Cuando el programa se inicia se mostrara una pequeña pantalla de carga, al lado izquierdo encontraremos un panel con botones los 
cuales nos dejaran navegar por las diferentes partes del programa, si damos click en el boton "Inicio"
se abrira un apartado donde se mostraran todos los productos que hay disponibles tambien se mostrara un carrito al igual que 
los botones "Agregar Nombre" "Confirmar Orden" "Level" para identificar el pedido, al hacer click en los productos,
se abrira una ventana y mostrara la descripcion del producto, el precio, una foto del producto y un boton para seleccionar la cantidad
abajo encontraremos 2 botones "Salir" y "Aceptar" click en "Cancelar" para volver a los producto, click en "Aceptar" para agregar 
el producto al carrito, click en boton "Carrito" para ver la lista de productos seleccionados, si damos click en "Confirmar Orden"
se validara si se ha ingresado un nombre sino es el cazo saldra error, luego de colocar un nombre y confirmar la orden
se mandara el Pedido a un DataGridView, click en boton "Pedidos" para ver el pedido, sus productos y el total a pagar
click en boton "Preparar" para mandarlo al Admin para que se empiece a preparar el pedido

//Todavia en proceso....
Las demas Funciones siguen en Proceso, pero la implementacion de la TAD cola y Lista ya estan implementadas correctamente
