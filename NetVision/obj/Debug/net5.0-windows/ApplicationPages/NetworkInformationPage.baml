   M S B A M L   `   `   `  ����D  @NetVision, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:NetVision.ApplicationPagesNetVision.ApplicationPages  5      7    1NetVision.ApplicationPages.NetworkInformationPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:NetVision.ApplicationPages     5        N� 
Background  �#404040 N� Title$ NetworkInformationPage��5
       � 	Resources 5       �� 
TargetType �� Property �� Value��%A  '��       '�� �     '�� -    '�� �    '�� }    �� 5   
   " ��6   .�5      ��  � ��$	 150��6&   �� 5       � ��$ 40��6'   �� 5       � �� �#ffd11a6+   �� 5       � ��$
 Bold"�6+   5      �� 5   
   " ��6   .�5      ��  � ��
 �   �6+   �� 5       � ��
 �����6+   5      �� 5   
   " ��6   .�5      ��  � ��
 �   �6+   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6,   �� 5       � ��$ Center=�64   5      �� 5   
   " ��6   .�5       ��  � ��
 �����6+   �� 5!       � ��$ 14(�6)   �� 5"       � ��$ 10q�6'   5#      �� 5$   
   " ��6   .�5%      ��  � ��
 �����6+   �� 5&       � ��$ 14(�6)   �� 5'       � ��$ 10q�6'   5(      5*      .��5+      �  � ColumnDefinitions 5,   
   �� 5-      $��* �6   �� 5.      $��2* �6    � RowDefinitions 50   
   �� 51      $��3* �6   �� 52      $��2* �6   .+�54   
   � -   5         �Name$ buttonsPanel��54      	 � Orientation$	 
Horizontal=�55      $��0��56      $��2��57      $��Center=�58      $��0,10,0,0q�59      5<      �� 5=   
   
 �� Orientation$
 Vertical=�6   $��0��5>      $��2��5?      .+�5B      �� $
 
Horizontal=�6   $��Center=�62   .+�5C      �� $��
Host name:��6   �� 5D      -   5         ��Name$ txtHost��5D      $��16(�6-   5E      �� 5G      $
 
Horizontal=�6   .+�5H      �� $��Domain name:��6   �� 5I      -   5        $ 	txtDomain��5I      5J      �� 5K      $
 
Horizontal=�6   .+�5L      �� $��Internet status:��6   A� 5M      -   5         A�Name$ statusLight��5M      
���  ��$��20��5N      $��20��6%   �� 5O      -   5        $ txtNet��5O      $��20(�6,   5P      5Q      R� 5S   
   -   5         R�Name$ cardTreeView��5S      $��3��5T      $��1��5U      $��	0,0,10,10q�5V      ��5W      �� *NetworkInfoModel+.@�5X      Q� -   5         Q�Name$ 	trvCardId��5X      $��Card Id��6.   .@�5Y      Q� ��6   �� *Id+5Z      Q� 5[      -   5        $ trvCardName��5[      $��	Card name��60   .@�5\      Q� ��6   �� *Name+5]      Q� 5^      -	   5        $ trvCardDesc��5^      $��Description��60   .@�5_      Q� ��6   �� *Description+5`      Q� 5a      -
   5        $ trvCardSpeed��5a      $��Speed��61   .@�5b      Q� ��6   �� *Speed+5c      Q� 5d      -   5        $ trvCardStatus��5d      $��Status��62   .@�5e      Q� ��6   �� *Status+5f      Q� 5g      -   5        $ trvGateways��5g      $��Gateway addresses��60   Q� 5h      -   5        $ trvDns��5h      $��DNS addresses��6+   Q� 5i      -   5        $ trvDhcp��5i      $��DHCP addresses��6,   5j      5k      5l      