   M S B A M L   `   `   `  ����  FunnyCafeManagerment)    #FunnyCafeManagerment.RegisterWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  LoginWindow��5   	   $	��400��5   	   $	��600��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	   
������  � Icon$ Images/coffee-cup.ico��5   	    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5       �� 
TargetType �� Property	 �� Value
 �� 
TargetType �� CornerRadius �� 
BottomLeft �� BottomRight �� TopLeft �� TopRight��%  '�       �� 5   
   " �6   .�5      ��  � ��	 5      �� 5      "
 �6&   .R�5      �� #��z��6!   #��z��5   !   $��1q�5   !    5      �� 5   "   $ 20Q�6/   $ 20Q�6?   $ 20Q�6P   $ 20Q�6]   5      5      5       5!      5"      .��5%      �� 
�������$ 20��6    
�������$��1q�6E   ._�5&   
   � .+�5(      �� 
���**��$��40��6(   $	��Top=�64   $ 	20,20,0,0��6L   ._�5)      � .+�5+      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $
��Left=�6U   $��10,0,0,0q�6p   .+�5,      �� $��Images/coffee-cup.ico��6    $��24��6?   $��24��6J   �� 5.      $��Registing...��6$   
�������$��16(�6K   $��Center=�6Y   $��10,0,0,0q�6t   5/      �� 52      $ 
Horizontal=�6!   $��Right=�6:   $��Center=�6V   $��0,0,10,0q�6q   .+�54      �� -   5        $��-��54   !   $��30��6-   $��30��68      WindowButtonStyle#��[  6a   �� 56      -   5        $	��□��56   !   $��30��6-   $��30��68   #��[  6a   �� 58      -   5        $��X��58   !   $��30��6-   $��30��68   
�������  CloseButtonStyle#��[ 6q   59      5:      5;      � 5>      $��0,40,0,0q�6   .+�5@      �� $��Center=�6   $	��358��65   $��Center=�6B   $	��598��6]   $#��./Images/login_background.png��6i   $
��Fill=�6�   �� 5C      $
��Left=�6   $	��300��64   $��	240,0,0,0q�6A   $��Center=�6T   $	��338��6o   ���#D7B08F$ 10��6�   ._�5D      � $��10q�6    � RowDefinitions 5E      �� 5F      .+�5H      �� $��Images/logo.png��6     J� RenderTransformOrigin$ 1.921,-0.147&�69   $��257,-21,-20,230q�6^   �� 5J      $��
Đăng kí��6    
�������$��20(�6E   $
��Bold"�6S   $��Center=�6e   $	��Top=�6�     
CustomFont#��[ 6�   $��0,14,0,0q�6�   �� 5M      $��	Username:��6    $��14(�64   $
��Bold"�6B   $
��Left=�6T   $	��Top=�6o   $��	20,60,0,0q�6�   
�������$��Italic$�6�   �� 5P        TextBoxStyle#��[ 6"   $	��202��6H   $��30��6T   $
��Left=�6`   $	��Top=�6{   $��
101,60,0,0q�6�   $��22(�6�   �� 5S      $��	Password:��6    $��14(�64   $
��Bold"�6B   $
��Left=�6T   $	��Top=�6o   $��	20,96,0,0q�6�   
�������$��Italic$�6�   G� 5V        PasswordBoxStyle#��[ 6&   $	��202��6P   $��30��6\   $
��Left=�6j   $	��Top=�6�   $��
101,95,0,0q�6�   $��22(�6�   �� 5X      $��C.Password:��6    $��14(�66   $
��Bold"�6D   $
��Left=�6V   $	��Top=�6q   $��
10,131,0,0q�6�   
�������$��Italic$�6�   G� 5Z      #��[ 6&   $	��202��6P   $��30��6\   $
��Left=�6j   $	��Top=�6�   $��101,130,0,0q�6�   $��22(�6�   �� 5\      $��Email:��6    $��14(�61   $
��Bold"�6?   $
��Left=�6Q   $	��Top=�6l   $��
33,166,0,0q�6�   
�������$��Italic$�6�   �� 5_      #��[ 6"   $	��202��6H   $��30��6T   $
��Left=�6`   $	��Top=�6{   $��101,165,0,0q�6�   $��22(�6�   �� 5c      -   5         ��Name$ LoginButton��5c   !   $��Đăng nhập��66     ButtonStyle#��[ 6J   $	��120��6o   $��30��6{   $
��Left=�6�   $	��Top=�6�   $��
24,225,0,0q�6�   ���#E3C241
�������6�   �� 5f      $��
Đăng kí��6!   #��[ 63   $	��120��6X   $��30��6d   $
��Left=�6p   $	��Top=�6�   $��177,225,0,0q�6�   ���#E3C241
�������6�   �� 5i      $��funnycoffee��6    $��14(�66   $
��Bold"�6D   $
��Left=�6V   $	��Top=�6q   
�������$��Italic$�6�   $��46��6�   $	��137��6�   5k      5l      5m      5n      5o      5p      