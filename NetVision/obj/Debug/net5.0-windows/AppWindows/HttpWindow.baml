   M S B A M L   `   `   `  ����D  @NetVision, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:NetVision.AppWindowsNetVision.AppWindows  5   	   %    NetVision.AppWindows.HttpWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:NetVision.AppWindows     5   	   ���#404040  � Title$  
HttpWindow��5	   	   $	��450��6   $	��800��6)    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � �� �#30D5C86+   �� 5       � ��$ 75��6&   �� 5       � ��$ 40��6'   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6#   �� 5      $��2* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��2* �6    .+�5      ��  �� Orientation$ Vertical=�6   $��0��60   $��2��6@   $��0,0,0,10q�6Q   .+�5       �� -   5        $��
msgTypeCmb��5       .@�5!      �� $��Params��6#   �� 5"      $
��Json��6#   �� 5#      $	��XML��6#   �� 5$      $
��Text��6#   5%      �� 5&      -   5         ��Name$ inputTextBox��5&      
���   �
�������$	��300��5)      $��0,50,0,0q�5*      	 �� 	IsEnabled$
	 True��5+      
 �� AcceptsReturn$

 True��5,       �� TextWrapping$
 Wrap=�5-       �� 
CaretBrush
 �   ���5/      ��  �� Path$ Content�50      �� 51      $ 
Horizontal=�6   $��0��63   $��1��6@   $��	10,0,10,0q�6P   .+�52      �� $ 
Horizontal=�6   $��Center=�66   .+�53      �� -   5        $��verbType��53      $	��100��6/   $��30��6;    �� SelectedValue 6G   �� $ Method��� 54      -   5        $ txtAddr��54      $	��200��6/   $��30��6;   $��50,0,0,0q�6G   
�������
���   ���6   �� $	 Url� �� Mode$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=��� 55      -   5         ��Name$ 
buttonSend��55      $
��Send��6-   ��6<   �� $ GetRequestCmd�56      57      �� 58      $ 
Horizontal=�6   $��1��62   $��1��6B   $��10,0,0,0q�6O   .+�59      �� -   5        $ resultPanel��59      $	��530��6/   $	��300��6;   
�������
���   ���6n   �� $ 	TextValue�$ TwoWay=�$ PropertyChanged=�5:      5;      5<      