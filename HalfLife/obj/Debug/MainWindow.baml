   M S B A M L   `   `   `  ����C  ?HalfLife, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:HalfLifeHalfLife  5   	       HalfLife.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:HalfLife     5   	     � Title$  	Half-Life��5   	   $	��201��6   $	��369��6(    � 
ResizeMode$ CanMinimize=�64    � WindowStartupLocation$ CenterScreen=�6M   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $"��Исходная масса:��6   $
��Left=�69   $��	10,13,0,0q�6T   $	��Top=�6g   �� 5   
   -   5        $ 
label_Copy��5      $"��Конечная масса:��6$   $
��Left=�6>   $��	10,41,0,0q�6Y   $	��Top=�6l   �� 5   
   -   5        $ Result_Label��5      $�� ��6&   $
��Left=�61   $��
10,103,0,0q�6L   $	��Top=�6`   $	��335��6x   $��Center=�6�   �� 5   
   -   5         ��Name$ InitialMass_TextBox��5      $
��Left=�6/   $��23��6J   $��
144,13,0,0q�6V    �� TextWrapping$
 Wrap=�6j   $	��Top=�6~   $	��201��6�   �� 5   
   -   5        $ ExpectedMass_TextBox��5      $
��Left=�60   $��23��6K   $��
144,41,0,0q�6W   $
 Wrap=�6k   $	��Top=�6   $	��201��6�   �� 5   
   -   5         ��Name$ Calculate_Button��5      $��Посчитать!��6+   $
��Left=�6@   $��
10,134,0,0q�6[   $	��Top=�6o   $	��335��6�   6�   �� 5   
   -   5        $ label_Copy1��5      $*��$Период полураспада:��6%   $
��Left=�6C   $��	10,72,0,0q�6^   $	��Top=�6q   �� 5   
   -   5        $ HalfLife_TextBox��5      $
��Left=�6,   $��23��6G   $��
144,72,0,0q�6S   $
 Wrap=�6g   $	��Top=�6{   $	��201��6�   5      5      