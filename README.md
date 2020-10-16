# NotificacionesWF
Notificaciones Tipo Windows 10,son formularios que se muestran en forma de notifcaciones parecidas a las de windows  10, estan realziadas en visual studio 2019 con el framework 4.7.2, se utiliza patron singleton

#info
1. NotificationWF.Instance.Title = "Notificacion tipo windows " ;//Establecer el titulo del mensaje
2. NotificationWF.Instance.Text = "Esta es na notificacion tipo windows";// establever el Cuerpo del mensaje
3. NotificationWF.Instance.BackColor = Color.Orange; //Establecer el color de fondo 
4. NotificationWF.Instance.TextColor = Color.Black;// Establecer el color de texto del cuerpo del mensaje
5. NotificationWF.Instance.TitleColor = Color.Black;// Establecer el color del texto del titulo del mensaje
6. NotificationWF.Instance.DivColor = Color.GreenYellow; // Establecer el color de fondo de la division entre el titulo y el texto del cuerpo del mensaje
7. NotificationWF.Instance.TimeToClose = 10; // Tiempo que le tomara a la notificacion en desaparecer
8. NotificationWF.Instance.ShowMessge();//Mostrar la notificacion en el escritorio de windows


![Mensajes like Windows.png](https://github.com/TuringD/NotificacionesWF/blob/main/Mensajes%20like%20Windows.png)
