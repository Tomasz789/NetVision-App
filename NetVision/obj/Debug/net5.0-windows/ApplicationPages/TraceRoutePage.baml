   M S B A M L   `   `   `  ����D  @NetVision, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:NetVision.ApplicationPagesNetVision.ApplicationPages  5      M INetVision.DataCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Bclr-namespace:NetVision.DataCore.Model;assembly=NetVision.DataCoreNetVision.DataCore.Model 5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      9!clr-namespace:NetVision.ViewModelNetVision.ViewModel  6O   /    )NetVision.ApplicationPages.TraceRoutePage   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:NetVision.ApplicationPages     5      VcontextBclr-namespace:NetVision.DataCore.Model;assembly=NetVision.DataCore     5      Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      7	viewmodel!clr-namespace:NetVision.ViewModel     6O     N� 
Background  �#404040 N� Title$ TraceRoutePage��5       � 	Resources 5       �� 
TargetType �� Property �� Value.  (NetVision.DataCore.Model.TraceEntryModel   
traceModel��%�  '��       '�� m     &	  z    �� 5   
   " ��6   .�5      ��  � ��$	 100��6&   �� 5       � ��$ 25��6'   5      �� 5   
   " ��6   .�5      ��  � ��$	 100��6&   �� 5       � ��$ 40��6'   �� 5       � �� �#00802b6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 0,0,0,20q�6'   �� 5       � ��
 �����6+   5        5   
   6"   5       .��5"      �  � ColumnDefinitions 5#   
   �� 5$      $��3* �6   �� 5%      $��* �6    � RowDefinitions 5'   
   �� 5(      $��3* �6   �� 5)      $��* �6   .+�5+   
   �� -   5         ��Name$ 	viewPanel��5,      	 �� Orientation$	 Vertical=�5-      $��0��5.      $��0��5/      50      �� 51   
   .��52      �� -   5        
 ��Name$
 viewMainPanel��52      ��6.   �� *ObservableTraceList+ �� View 53      �� 54      .P�55      �� -   5        	hopColumn��$	��Hop��55   =    �� Width$	 100��6{    �� DisplayMemberBinding 6J   ��  �� Path$ 
HopCounter�6{   �� 56      -   5        
hostColumn��$
��Host��56   >   $	 100��6L    6X   �� $ HostName��� 57      -   5        
addrColumn��$	��Ip ��57   >   $	 100��6y    6K   �� $ Address�6y   �� 58      -   5        timeoutColumn��$��Timeout��58   A    6R   �� $ Timeout�59      5;      5<      �� 5>   
   $	 
Horizontal=�6   $��1��6.   $��50��6>   6M   �� 5?   
   $	 Vertical=�6   $��0��6,   $��1��69   $��Center=�6I   .+�5@      �� -   5         ��Name$ saveFileButton��5@      $��30��6-   $��30��68   .��5A      �� $ ��/ApplicationPages/save.png��6   5B      �� 5C      $
��Host��6   $��1��6#   �� 5D      ��6   �� $ HostName� �� Mode$ OneWayToSource=� �� ValidatesOnDataErrors$
 True�� �� UpdateSourceTrigger$ PropertyChanged=�.��6�    =� ErrorTemplate 5E      �� 5F      .R�5G      �� .+�5H      �� �� 5I      
���  ��
�������$
��Bold"�5L   (   $��10(�5M   (   $��5q�5N   (   ��5I   (   �� *ErrorContent+5N   (   5Q      5R      .��5S   ,   5T      �� 5U      $	��TTL��6   *  $MahApps.Metro.Controls.NumericUpDown  5V         Maximum$ 30Q�6W      Minimum$ 1Q�6d   $	��158��6p   
�������   Interval$ 1Q�6�   $��23��6�      Value 6    �� $ 
HopCounter�$ OneWayToSource=�6�   �� 5W      $��Timeout��6   �� 5X      ��6   �� $ Timeout�$ OneWayToSource=�$
 True��$ PropertyChanged=�.��6�    5Y      �� 5Z      .R�5[      �� .+�5\      �� �� 5]      
���  ��
�������$
��Bold"�5`   (   $��10(�5a   (   $��5q�5b   (   ��5]   (   �� *ErrorContent+5b   (   5e      5f      .��5g   ,   5h      5i      �� 5j   
   $	 Vertical=�6   $��1��6,   $��1��69   .+�5k      �� -   5        $ btnStart��5k      $��Start��6'   
��� d ���6c   �� *GetTraceRouteCmd+�� 5l      -	   5        $ btnStop��5l      $
��Stop��6&   
���  ��65   5n      �� 5o   
   $	 
Horizontal=�6   $��Center=�5p      $��1��5q      .+�5r      �� $��1��5s      $��0��5t      $	��250��5u      .@�5w      �  5x      �� 5y      $��* �6+   �� 5z      $��* �6+    5|      �� 5}      $��* �6(   �� 5~      $��* �6(   �� 5      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   .+�5�      �� $��Summary��5�      
�������$
��Auto��5�      $��0��5�      $��0��5�      $��2��5�      
����� �$
��Bold"�5�      �� 5�      $��1��5�      
�������
���   �$��Counts��5�      �� 5�      $��1��5�      $��1��5�      
�������
���   ���5�      �� *
HopCounter+�� 5�      $��2��5�      $��0��5�      
�������
���   �$
��Host��5�      �� 5�      $��2��5�      $��1��5�      
�������
���   ���5�      �� *
HostName+�� 5�      $��3��5�      $��0��5�      
�������
���   �$��Avg Timeout��5�      �� 5�      $��3��5�      $��1��5�      
�������
���   ���5�      �� *
AvgTimeout+�� 5�      $��4��5�      $��0��5�      
�������
���   �$��Min Timeout [ms]��5�      �� 5�      $��4��5�      $��1��5�      
�������
���   ���5�      �� *
MinTimeout+�� 5�      $��5��5�      $��0��5�      
�������
���   �$��Max timeout [ms]��5�      �� 5�      $��5��5�      $��1��5�      
�������
���   ���5�      �� *
MaxTimeout+5�      5�      )  #MahApps.Metro.Controls.ProgressRing  5�      -
   5          Name$ progRing��5�      $��20,0,0,0q�5�      
��� ���   IsActive$ False��5�      5�      5�      5�      5�      