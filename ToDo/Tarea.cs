namespace EspacioTarea;

public class Tarea//declaro una clase publica llamada Tarea, que servira como molde para crear objetos de tipo Tarea
{
    public int TareaID {get; set; }
    //get -> obtener (leer)
    //set -> modificar (guardar)
    public string Descripcion {get; set; }
    public int Duracion {get; set; } //Validar que este entre 10 y 100

    //Puedes anadir un constructor y metodos auxiliares si lo consideras necesario
}