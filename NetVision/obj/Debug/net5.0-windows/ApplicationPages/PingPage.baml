   M S B A M L   `   `   `  ����D  @NetVision, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:NetVision.ApplicationPagesNetVision.ApplicationPages  5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   9!clr-namespace:NetVision.ViewModelNetVision.ViewModel  6Q   )    #NetVision.ApplicationPages.PingPage   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <controls'using:Microsoft.Toolkit.Uwp.UI.Controls     5   	   :local(clr-namespace:NetVision.ApplicationPages     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   7	viewmodel!clr-namespace:NetVision.ViewModel     6Q     N� Title$  PingPage��5
   	   $	��250��6   $	��750��6'    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 75��6&   �� 5       � ��$ 50��6'   �� 5       � ��$ 16(�6)   �� 5       � ��$ 	10,10,0,0q�6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$
 list��5      $	��300��6!   $	��Top=�6.   $��0��6F   ��6S   �� *	PingModel+ �� View 5      �� 5      .P�5      �� $��Witryna��6%    �� Width$	 100��66   	 �� DisplayMemberBinding	 6B   �� *Host+�� 5      $��Adres��6%   $	 100��6]   	 64   �� *	Address+6]   �� 5      $��Czas ��6%   $ 50��6]   	 64   �� *	Timeout+6]   �� 5       $��Status��6%   $ 50��65   	 6@   �� *State+�� 5!      $
��TTL ��6%   $	 100��6X   	 63   �� *TTL+6X   �� 5"      $��Wielkość bufora danych��6%   $	 150��6s   	 6E   �� *BufferLength+6s   �� 5#      $
��Dane��6%   $ 50��63   	 6>   �� *Data+5$      5&      �� 5'   
   
 �� Orientation$
 
Horizontal=�6   $��Center=�6.   $��1��6K   .+�5(      �� $
��Host��6   $��50��6#   $��41��6.    J� RenderTransformOrigin$ 0.593,0.255&�6:   �� 5)      -   5         ��Name$ ipAddTxt��5)      $	��100��6(   $��20��64   ��6@   �� *	Address+�� 5*      $	��TTL��6   $��44��6"   $ 
0.125,0.61&�6-   *  $MahApps.Metro.Controls.NumericUpDown  5+         Value 6    �� *TTL+�� 5,      $
��Dane��6   �� 5-      $��50��6   $��20��6!   ��6-   �� *Data+5.      �� 5/   
   $
 
Horizontal=�6   $��Center=�6.   $��2��6K   .+�50      �� $��Powt.��6   �� 51      -   5        $��	cmbCounts��51      $��50��6+   $��20��66   ��6B   �� *Counts+�� 52      $��Timeout��6   �� 53      -   5        $ 
timeoutTxt��53      $��50��62   $��20��6=   ��6I   �� *	Timeout+�� 54      -   5         ��Name$ 
btnGetPing��54      $
��Ping��6)   ���#30D5C8$
��Bold"�6N   $��14(�6`   $��1��6n   $	��100��6{   $��50��6�   $��20,0,0,0q�6�   $��4��6�   
���������6�   ��  �� Path$ GetPingCommand�6�   �� 55      -   5        $ saveFile��55      $
��Save��6'   $��20,0,0,0q�66   ���#30D5C8
�������$��50��6�   $��50��6�   56      57      58      