   M S B A M L   `   `   `  ����I  EMiBlockDeNotas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MiBlockDeNotasMiBlockDeNotas  5   	       MiBlockDeNotas.MainWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MiBlockDeNotas     5   	     � Icon$  /Notepad_22522.ico��5   	    � Title$ Bloc de Notas Trassierra��5
   	   $	��450��6*   $	��550��67    � WindowStartupLocation$ CenterScreen=�6C    � WindowStyle$ 
ToolWindow=�6h   .��5      � $��Center=�6   $��Center=�6(   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6   � 5      $ White��6    � Offset$ 1Q�6-   5       � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��350 �6   	 � ColumnDefinitions	 5   
   �� 5      $
��1.1* �6   �� 5      $��0.83* �6   �� 5      $��0.83* �6   �� 5      $��0.83* �6   �� 5      $��0.83* �6   �� 5      $
��1.1* �6   .+�5!   
   �� -   5        
 ��Name$
 	txtOrigen��5!      $��0��6%   $��0��62   $��95��6B   $��40��6M   $��15,0,0,0q�6Y    �� TextWrapping$
 Wrap=�6k   �� 5"   
   -   5        $
 
txtDestino��5"      $��0��6&   $��5��63   $��95��6C   $��40��6N   $��0,0,15,0q�6Z   $
 Wrap=�6l   �� 5#   
   -   5         ��Name$ buttonAbrir��5#      $��0��6&   $��1��63   $��60��6C   $��30��6N   $��Center=�6Z   $��Center=�6w   $��Abrir��6�   6�   �� 5$   
   -   5        $ 	btnBorrar��5$      $��0��6$   $��2��61   $��60��6A   $��30��6L   $��Center=�6X   $��Center=�6u   $��Borrar��6�   6�   �� 5%   
   -   5        $ btnSalir��5%      $��0��6#   $��3��60   $��60��6@   $��30��6K   $��Center=�6W   $��Center=�6t   $��Salir��6�   6�   �� 5&   
   -   5        $ 
btnGuardar��5&      $��0��6%   $��4��62   $��60��6B   $��30��6M   $��Center=�6Y   $��Center=�6v   $��Guardar��6�   6�   �� 5'   
   $��1��6   $��0��6"   $��6��62   $��Center=�6F   $��Center=�6c   .+�5(      �� -   5        $
 txtDocumento��5(      $	��340��6,   $	��510��69   $
 Wrap=�6E    �� AcceptsReturn$
 True��6Y   " �� VerticalScrollBarVisibility$ Visible=�6n   5)      5+      5,      