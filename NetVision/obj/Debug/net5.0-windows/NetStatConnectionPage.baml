   M S B A M L   `   `   `  ����D  @NetVision, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NetVision	NetVision  5      %    NetVision.NetStatConnectionPage   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:NetVision     5        N� Title$  NetStatConnectionPage��5	       � 	Resources 5       �� 
TargetType �� Property �� Value��%  '��       '�� �     '��     �� 5   
   " ��6   .�5      ��  � �� �#30D5C86+   �� 5       � ��
 �����6+   �� 5       � ��$	 100��6&   �� 5       � ��$ 	20,0,20,0q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ Stretch=�64   5      �� 5   
   " ��6   .�5      ��  � ��$ 20q�6'   �� 5       � ��$	 Top=�62   �� 5       � ��$
 Left=�64   �� 5       � ��$	 200��6&   �� 5       � ��$	 500��6'   5      5      .��5      � .+�5   
   �� .@�5       �� ��5!      �� 5"      $	��TCP��6    ���#30D5C8
�������$
��Bold"�5%       $��20��5&       $	��100��5'        �� TextAlignment$ Center=�5(       .��5*      ��  �� Orientation$ Vertical=�6   .+�5+      �� -   5         ��Name$ 	txtSearch��5+      $	��200��5,      $��30��5-      $��Right=�5.      $��0,0,10,0q�5/      50      �� 51      -   5         ��Name$ connectionList��51      $��10q�52      $	��300��53      $��1��54      	 �� View	 56      �� 57      .P�58   "   �� 
 �� Width$	
 150��61   $��Local Endpoint��6=    �� DisplayMemberBinding 6U   �� *LocalEndPoint+�� 59   "   $	
 150��61   $��Remote Endpoint��6=    6V   �� *RemoteEndPoint+�� 5:   "   $	
 150��61   $��State��6=    6L   �� *State+5;      5=      �� 5?      -   5         ��Name$ btnShowConnections��5?      $��30��5@      $
��Show��5A      $��2��5B      5C      5D      5E      �� 5F      ��5G      �� 5H      $	��UDP��6    ���#30D5C8
�������$
��Bold"�5K       $ Center=�5L       .��5N      �� $ Vertical=�6   .+�5O      �� -   5        $ txtUdpSearch��5O      $	��200��5P      $��30��5Q      $��Right=�5R      $��0,0,10,0q�5S      5T      �� 5U      -   5        $ UdpconnectionList��5U      $��10q�5V      $	��300��5W      $��1��5X      	 5Z      �� 5[      .P�5\   "   �� $	
 150��61   $��Address��6=    6N   �� *	Address+�� 5]   "   $	
 150��61   $
��Port��6=    6K   �� *Port+�� 5^   "   $	
 150��61   $��Address Family��6=    6U   �� *AddressFamily+5_      5a      �� 5c      -   5        $ btnShowUdpConnections��5c      $��30��5d      $
��Show��5e      $��2��5f      6&   5h      5i      �� 5j      ��5k      �� 5l      $��TCP IPv4��6    ���#30D5C8
�������$
��Bold"�5o       $ Center=�5p       .��5r      �� 	 5s      �� 5t      .P�5u      �� 5v      5x      5y      5z      5{      5|      