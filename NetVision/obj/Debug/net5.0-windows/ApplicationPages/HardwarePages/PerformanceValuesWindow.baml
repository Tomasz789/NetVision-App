   M S B A M L   `   `   `  ����D  @NetVision, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:NetVision.ApplicationPages.HardwarePages(NetVision.ApplicationPages.HardwarePages  5   	   O,clr-namespace:NetVision.ViewModel.ConvertersNetVision.ViewModel.Converters  5   	   F    @NetVision.ApplicationPages.HardwarePages.PerformanceValuesWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:NetVision.ApplicationPages.HardwarePages     5   	   :a,clr-namespace:NetVision.ViewModel.Converters     5   	   -   5        ���#404040  � Title$  NV Resource Monitor��5
   	   $	��640��6%   $	��960��62    � 	Resources 5       �� 
TargetType �� Property �� Value6   0NetVision.ViewModel.Converters.CpuValueConverter   CpuValueConverter��%�   '��       &	  �     �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   5        5   
   6   5      .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5"   
    � -   5          �Name$ cpuPlot��5"      $��0��5#      $��0��5$      $��2��5%      $��0,10,0,0q�5&      6$    � 5'   
   -   5        $ ramPlot��5'      $��0��5(      $��1��5)      $��3��5*      $��	0,156,0,0q�6!   66   �� 5+   
   $��1��6   $��0��6    $��CPU %��6-   $��Center=�6=   $��Center=�6a   �� 5,   
   $��1��6   $��Total RAM  [MB]��6    $��Center=�6:   $��Center=�6^   $��	0,156,0,0q�6�   $��2��6�   �� 5-   
   $��1��6   $��1��6    $��Available RAM [%]��6-   $��Center=�6I   $��Center=�6m   $��	0,156,0,0q�6�   $��2��6�   �� 5.   
   $��Current Usage of RAM [MB]��6   $��Center=�64   $��Center=�6X   $��1��6z   $��3��6�   �� 5/   
   -   5         ��Name$ labCPU��5/      $��2��6    $��0��60   $��Center=�6=   $��Center=�6a   ��6�   �� *	CPU_Usage+��50      �� 51      " ��6   	 �� Triggers	 52      �� 53      
 �� Binding
 6&   �� *	CPU_Usage+ �� 	Converter# [   �� Value True6r   .a�54      ��  � ��
 �  ��6;   55      57      59      �� 5:   
   -   5        $ labRAM��5:      $��2��6    $��Center=�60   $��Center=�6T   $��	0,156,0,0q�6�   $��2��6�   ��6v   �� *RAM_Total_Usage+6�   �� 5;   
   -   5        $ labRamAv��5;      $��2��6"   $��1��62   $��Center=�6?   $��Center=�6c   $��	0,156,0,0q�6�   $��2��6�   ��6�   �� *RAM_Available+��5<      �� 5=      " ��6   	 5>      �� 5?      
 6&   �� 5A      5C      �� 5D   
   -   5        $ 
labRamCurr��5D      $��2��6$   $��2��64   $��Center=�6A   $��Center=�6e   $��	0,156,0,0q�6�   $��2��6�   ��6�   �� *RAM_Current+6�   �� 5E   
    �� Orientation$ Vertical=�6   $��Center=�6,   $��Center=�6I   $��3��6d   .+�5F      �� -   5         ��Name$ buttonChartSettings��5F      $��50��62   $��50��6=   6I   5G      5H      5I      