   M S B A M L   `   `   `  ����D  @NetVision, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:NetVision.AppWindowsNetVision.AppWindows  5   	   )    #NetVision.AppWindows.SaveFileWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:NetVision.AppWindows     5   	   ���#404040  � Title$  	Save File��5	   	   $	��200��6   $	��400��6(    � 	Resources 5       �� 
TargetType �� Property �� Value��%�  '��       '�� p     �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��
 �   �6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 50��6&   �� 5       � ��$ 30��6'   �� 5       � �� �#30D5C86+   �� 5       � ��$
 Bold"�6+   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5    
   �� 5!      $��* �6   �� 5"      $��* �6   �� 5#      $��* �6   �� 5$      $��* �6   �� 5%      $��* �6   .+�5'   
   �� $
��Type��6   $��0��6   	� 5(   
   -   5         	�Name$ txtRadioButton��5(      $	��TXT��6.   $��0��6<   $��1��6I   	� 5)   
   -   5        $ xmlRadioButton��5)      $	��XML��6.   $��2��6<   $��0��6L   �� 5*   
   $
��Name��6   $��1��6   �� 5+   
   -   5         ��Name$ txtFileName��5+      $��report��6'   $��1��65   $��1��6B   $��3��6R   �� 5,   
   $
��Path��6   $��2��6   �� 5-   
   -   5        $ txtFilePath��5-      $��2��6'   $��1��64   $��2��6D   �� 5.   
   -   5        	 ��Name$	 
buttonSave��5.      $
��Save��6%   $��1��64   $��4��6D   �� 5/   
   -   5        $	 buttonCancel��5/      $��Cancel��6'   $��2��68   $��4��6H   �� 50   
   -   5        $	 buttonBrowse��50      $	��...��6'   $��50��65   $��3��6@   $��2��6P   51      52      