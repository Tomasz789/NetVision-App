   M S B A M L   `   `   `  ����D  @NetVision, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NetVision	NetVision  5   	       NetVision.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:NetVision     5   	   -   5          � Title$  Net Vision 1.0��5   	   $	��640��6    $	��960��6-   ���#808080.��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��4* �6   .+�5   
   �� -   5         ��Name$ buttonMainPage��5      $
��Home��6)   $��0��68   �� 5   
   -   5        $ buttonInfos��5      $
��Info��6&   $��1��65   �� 5   
   -   5        $ buttonBiosInfo��5      $
��Bios��6)   $��2��68   �� 5   
   -   5        $ buttonDiagnostics��5      $��Diagnostics��6,   $��3��6B   �� 5   
   -   5        $ buttonMonitor��5      $��	Resources��6(   $��4��6<   �� 5   
   -   5        $ 
buttonHelp��5      $��About��6%   $��5��65    � 5   
   -   5          �Name$ 	PagePanel��5        � NavigationUIVisibility$ Hidden=�6#   $��1��6D   $��6��6Q   5      5      