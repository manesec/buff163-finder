   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   O KMane Buff 163 Finder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Mane_Buff_163_FinderMane_Buff_163_Finder 5   	   "   Mane_Buff_163_Finder.Setting   5      Cmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Mane_Buff_163_Finder     5   	   -   5          � 
ResizeMode$  NoResize=�5       � Title$ Setting��5	   	   $	��340��6   $	��620��6&   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      6   .+�5   
   �� $��10q�6   $��0��6!   .+�5      �� $��Proxy Setting��6   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ check_proxy��5      $��Pass Socks5��64   $��0 0 20 0q�6J   6^   �� 5      -   5         ��Name$ textbox_proxy��5      $��127.0.0.1:10808��65   $	��100��6L   6Z   5      5      �� 5      $��Fetch��6   .��5      �� .+�5      �� $ 
Horizontal=�6!   .+�5      �� $��Delay Page = ��6    6:   �� 5       -   5        $
 t_dp��5    "   $��40��60   $��10��6;   6G   �� 5!      $��
s + Random��6    67   �� 5"      -   5        $ t_dpr��5"   "   $��40��61   $��10��6<   6H   �� 5#      $��s��6    6.   5$      �� 5&      $ 
Horizontal=�6!   .+�5'      �� $��Max Page = ��6    68   �� 5(      -   5        $
 t_mp��5(   "   $��40��60   $��10��6;   6G   �� 5)      $��	 + Random��6    66   �� 5*      -   5        $ t_mpr��5*   "   $��40��61   $��10��6<   6H   �� 5+      $��s��6    6.   5,      �� 5.      -   5        $ c_steam��5.      $"��Try to use Steam Store Price��60   6Y    � 	Resources 50       �� 
TargetType	 �� Property
 �� Value��%\   '��       �� 51      " ��6    .�52      �� 	 � ��$
 0 0 0 5q�67   6I   53      54      55      56      �� 59      $��Notification��6   .��5:      �� .+�5;      �� -	   5        $ c_find��5;      $!��Show box when it find goods��6/   $��0 0 0 5q�6U   6h   �� 5<      -
   5        $ c_finish��5<      $��Show box when it finish��61   6U   5=      5>      5@      �� 5C   
   $��10q�6   $��1��6!   .+�5D      �� $��Cookie��6   .��5E      �� .+�5F      �� -   5        $ t_cook��5F      $��58��6.    �� TextWrapping$
 Wrap=�6:    �� AcceptsReturn$
 True��6N   6e   5G      5H      �� 5J      $��Filter��6   .��5K      �� .+�5L      �� $ 
Horizontal=�6!   .+�5M      �� $��	Price in ��6    66   �� 5N      -   5        $	 tpm��5N   "   $��40��6/   $��10��6:   6F   �� 5O      $	�� ~ ��6    60   �� 5P      -   5        $
 tpma��5P   "   $��40��60   $��80��6;   6G   �� 5Q      $	��RMB��6    60   5R      �� 5S      $ 
Horizontal=�6!   .+�5T      �� $��Rate Small and equel ��6    6B   �� 5U      -   5        $ t_rate��5U   "   $��40��62   $	��0.7��6=   6J   5V      �� 5X      $ 
Horizontal=�6!   .+�5Y      �� $(��"Sell number bigger and equel than ��6    6O   �� 5Z      -   5        $ tsell��5Z   "   $��40��61   $��50��6<   6H   5[      �� 5\      -   5        $ ccsco��5\      $��
Fetch CSGO��6.   $��0 0 0 5q�6C   6V   �� 5]      -   5        $ cdota��5]      $��Fetch Dota2��6.   6F   5^       5_      ��%\   '��       �� 5`      " ��6   .�5a      �� 	 � ��$
 0 0 0 5q�63   6E   5b      5c      5d      5f       5h   
      MahApps.Styles.GroupBox �� BasedOn+   %MahApps.Metro.Controls.ControlsHelper2   ,MahApps.Metro.Controls.HeaderedControlHelper��%5  '��       7   �� 5i      " ��6   8   .�5j      �� 	 �@ ContentCharacterCasing$
 Normal=�6N   6_   �� 5k      	 �@ HeaderBackground
 �#829bd96a   �� 5l      	 � ��

 �����6?   �� 5m      	 � ��
 �#829bd96B   �� 5n      	 � ��$
 0 0 0 10q�6+   6>   5o      5p      5q      5r      