   M S B A M L   `   `   `  ����G  CIGraficasIES, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:IGraficasIESIGraficasIES  5   	       IGraficasIES.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:IGraficasIES     5   	     � Title$  IES Trassierra��5   	   $	��450��6    $	��700��6-    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$ 
ToolWindow=�5
   	   .��5      � -   5         �Name$ Grid_Principal��5      .+�5   
   �� -   5         ��Name$ stkPanel��5      $��2��6'   $��0,0,0,8q�6;   .+�5      o� -   5         o�Name$ mimenu��5      .@�5      m� -   5         m�Name$ menuArchivo��5      $��_Archivo��60   .@�5      m� -   5        $ 	menuAbrir��5      $��Abrir��62   6A   �� 5      m� 5      -   5        $��Salir��5       m� Icon 5      �� 5      -   5         ��Name$ 	menuSalir��5   $   5      5      m� 5      -   5        $ 
menuFuente��5      $��_Fuente��6/   .@�5      m� -	   5        $ negrita��5      $��_Negrita��60   	 m� IsCheckable$
	 True��6B   6o   m� 5      -
   5        $ cursiva��5      $��_Cursiva��60   $
	 True��6B   6o   5      m� 5      -   5        $ menuFiltros��5      $��F_iltros��60   .@�5       m� -   5        $:��4Edad mayor de 35 (nombre, apellidos, edad y materia)��5       6]   m� 5!      -   5        $1��+Año Ingreso igual o superior a 2010 (todo)��5!      6S   m� 5"      -   5        $g��aAño Ingreso igual o superior a 2010 y Estado Civil es casado (nombre, apellidos, año y e.civil)��5"      6�   m� 5#      -   5        $~��xEstatura superior a 160 y ordenados por Estatura descendente y Peso descendente (nombre, apellidos, edad,estatura, peso)��5#      6�   5$      m� 5&      -   5        $ menuAgrupacion��5&      $��A_grupación��63   .@�5'      m� -   5        $L��FAgrupar por E.Civil y mostrar nombre, apellidos, edad, peso y estatura��5'      6o   m� 5(      -   5        $=��7Agrupar por E.Civil y motrar cuántos hay en cada grupo��5(      6_   m� 5)      -   5        $^��XAgrupar por Rangos de Edad, orden descendente por Edad y mostar nombre, apellidos, email��5)      6�   m� 5*      -   5        $���}Agrupar por Seguro Médico, cuando la edad es igual o superior a 40, orden peso y apellidos (nombre, apellidos, seguro, peso)��5*      6�   5+      5-      5/      � 51   
   -   5        $ Grid_Central��51      
 � RowDefinitions
 52      �� 53      $	��10* �6    �� 54      $	��91* �6    �� 55      $��5* �6    �� 56      $	��87* �6    �� 57      $
��107* �6     � ColumnDefinitions 59      �� 5:      $	��15* �6#   �� 5;      $	��10* �6#   �� 5<      $	��15* �6#   �� 5=      $	��15* �6#   �� 5>      $	��20* �6#   �� 5?      $	��10* �6#   �� 5@      $	��15* �6#   .+�5C      �� $��Nombre��6   $
��Left=�6%   $��	10,48,0,0q�6@   $��1��6S   $	��Top=�6`   �� 5D      $��	Apellidos��6   $
��Left=�6(   $��	10,90,0,0q�6C   $��1��6V   $	��Top=�6c   �� 5E      $
��Edad��6   $
��Left=�6#   $��10,6,0,0q�6>   $��2��6P   $	��Top=�6]   $��31��6u   $��62��6�   $��2��6�   �� 5F      $��3��6   $��Email��6$   $
��Left=�64   $��	32,48,0,0q�6O   $��1��6b   $	��Top=�6o   �� 5G      $��2��6   $��Año Ingreso��6$   $
��Left=�6:   $��10,1,0,0q�6U   $��3��6g   $	��Top=�6t   �� 5H      $��3��6   $��Tipo Funcionario��6$   $
��Left=�6?   $��92,1,0,0q�6Z   $��3��6l   $	��Top=�6y   $	��107��6�   $��2��6�   �� 5I      $��5��6   $��	S.Médico��6$   $
��Left=�67   $��0,1,0,0q�6R   $��3��6c   $	��Top=�6p   �� 5J      $��4��6   $��Destino definitivo��6$   $
��Left=�6A   $��1,75,0,0q�6\   $��1��6n   �� 5K      $��6��6   $��1��6&   $
��Left=�63   $��Center=�6N   $��50��6i   $��52��6t   $��0,0,0,0q�6�   .��5L      �� -   5        $��lblRutaFoto��5L      $
��Wrap=�6/   $��Normal$�6C   $��Normal&�6V   $��Arial Narrow)�6k   $��13(�6�   $��2��6�   $y�Hidden=�6�   	Ruta foto5N      5O      �� 5P      -   5         ��Name$ txtRutaFoto��5P      $��6��6+   $��1��6<   $
��Left=�6I   $��26��6d    �� TextWrapping$
 Wrap=�6p   $��Center=�6�   $��	10,70,0,0q�6�   $��90��6�   $��Arial)�6�   $��Italic$�6�   $y�Hidden=�6�   �� 5R      -   5         ��Name$ chb_DestinoDefinitivo��5R      $��3��66   $��1��6F   $
��Left=�6S   $	��Top=�6n   $��	87,80,0,0q�6�   �� 5T      -   5        $ 	txtNombre��5T      $��1��6)   $��2��69   $
��Left=�6M   $��0,52,0,0q�6h   $��1��6z   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   �� 5U      -   5        $ txtApellidos��5U      $��1��6,   $��3��6<   $
��Left=�6P   $��0,95,0,0q�6k   $��1��6}   $
 Wrap=�6�   $	��Top=�6�   $	��210��6�   6�   �� 5V      -   5        $ txtAnno��5V      $��3��6'   $
��Left=�67   $��24��6R   $��6,2,0,0q�6^   $��3��6o   $
 Wrap=�6|   $�� ��6�   $	��Top=�6�   $��77��6�   �� 5W      -   5        $ txtMail��5W      $��3��6'   $��3��67   $
��Left=�6K   $��18��6f   $��	87,52,0,0q�6r   $��1��6�   $
 Wrap=�6�   $	��Top=�6�   $	��187��6�   �� 5Y      -   5         ��Name$ cbEdad��5Y      $��1��6(   $
��Left=�68   $��0,2,0,0q�6S   $��3��6d   $	��Top=�6q   $��48��6�   �� 5[      -   5         ��Name$ lbSeguro��5[      $��6��6(   $
��Left=�68   $��0,2,0,0q�6S   $��3��6d   $	��Top=�6q   $��70��6�    �� SelectedValuePath$ Content��6�   .@�5\      �� .��6   
S.Social6(   �� 5]      .��6   Muface6&   5^      	� 5`      -   5         	�Name$ rdbPracticas��5`       	� 	GroupName$ tipousu��60   $��0,30,0,0q�6D   $��3��6V   $��4��6c   $��En Prácticas��6s   $
��Left=�6�   $	��Top=�6�   $	��146��6�   $��15��6�   	� 5a      -    5        $ 
rdbCarrera��5a      $ tipousu��6.   $��3��6B   $��4��6O   $��
De Carrera��6_   $
��Left=�6t   $��Center=�6�   $	��146��6�   $��15��6�   $��0,0,0,11q�6�   �� 5c      -!   5         ��Name$ txtBlockMedico��5c      $��6��60   $��Center=�6@   $��63��6]   $��0,6,0,0q�6i   $��3��6z   $
��Wrap=�6�   $�� ��6�   $	��Top=�6�   $��85��6�   �� 5e      -"   5        $ imgFoto��5e      $��6��6%   $��1��65   $
��Left=�6B   $��Center=�6]   $
��Auto��6x   $
��Auto��6�   $��2��6�   $��2��6�   $y�Visible=�6�   $��
0,20,10,20q�6�   5f      � 5h   
   -#   5        $ Grid_Botones��5h      
 5i      �� 5j      $	��10* �6    �� 5k      $	��91* �6    �� 5l      $��5* �6    �� 5m      $	��87* �6    �� 5n      $
��107* �6     5p      �� 5q      $	��15* �6#   �� 5r      $	��10* �6#   �� 5s      $	��15* �6#   �� 5t      $	��15* �6#   �� 5u      $	��20* �6#   �� 5v      $	��10* �6#   �� 5w      $	��15* �6#   .+�5z      �� -$   5         ��Name$ 
btnPrimero��5z       � ToolTip$ Primero��6)    ^� ShowOnDisabled$
 True��6;   $
��Left=�6v   $��40��6�   $	��Top=�6�   $��40��6�   $��1��6�   $��4��6�   $��0,11,0,0q�6�   .��5{      ]� .+�5|      �� -%   5        $ 
imgPrimero��5|      62   5}      5~      �� 5      -&   5        $ btnAnterior��5      $ Anterior��6*   $
 True��6=   $
��Left=�6y   $��40��6�   $	��Top=�6�   $��40��6�   $��2��6�   $��4��6�   $��0,11,0,0q�6�   .��5�      ]� .+�5�      �� -'   5        $ imgAnterior��5�      63   5�      5�      �� 5�      -(   5        $ 
btnAgregar��5�      $ Nuevo usuario��6)   $
 True��6A   $��Right=�6z   $��40��6�   $	��Top=�6�   $��40��6�   $��2��6�   $��4��6�   $��0,11,0,0q�6�   .��5�      ]� .+�5�      �� -)   5        $ 
imgAgregar��5�      62   5�      5�      �� 5�      -*   5        $ btnModificar��5�      $ 
Actualizar��6+   $
 True��6@   $
��Left=�6e   $��40��6�   $	��Top=�6�   $��40��6�   $��3��6�   $��4��6�   $��0,11,0,0q�6�   .��5�      ]� .+�5�      �� -+   5        $ imgModificar��5�      64   5�      5�      �� 5�      -,   5        $ btnEliminar��5�      $ Eliminar usuario��6*   $
 True��6E   $��Right=�6j   $��40��6�   $	��Top=�6�   $��40��6�   $��3��6�   $��4��6�   $��	0,11,25,0q�6�   .��5�      ]� .+�5�      �� --   5        $ imgEliminar��5�      63   5�      5�      �� 5�      -.   5        $ btnCancelar��5�      $ Cancelar��6*   $
 True��6=   $
��Left=�6y   $��40��6�   $	��Top=�6�   $��40��6�   $��4��6�   $��4��6�   $��0,11,0,0q�6�   .��5�      ]� .+�5�      �� -/   5        $ imgCancelar��5�      63   5�      5�      �� 5�      -0   5        $ 
btnGuardar��5�      $ Guardar��6)   $
 True��6;   $
��Left=�6`   $��40��6{   $	��Top=�6�   $��40��6�   $��4��6�   $��4��6�   $��	40,11,0,0q�6�   .��5�      ]� .+�5�      �� -1   5        $ 
imgGuardar��5�      62   5�      5�      �� 5�      -2   5        $ btnSiguiente��5�      $ 	Siguiente��6+   $
 True��6?   $��Right=�6|   $��40��6�   $	��Top=�6�   $��40��6�   $��4��6�   $��4��6�   $��0,11,0,0q�6�   .��5�      ]� .+�5�      �� -3   5        $ imgSiguiente��5�      64   5�      5�      �� 5�      -4   5        $ 	btnUltimo��5�      $ Último��6(   $
 True��69   $��Right=�6s   $��40��6�   $	��Top=�6�   $��40��6�   $��5��6�   $��4��6�   $��0,11,0,0q�6�   .��5�      ]� .+�5�      �� -5   5        $ 	imgUltimo��5�      61   5�      5�      5�      5�      5�      