   M S B A M L   `   `   `  ����O  KFunnyCafeManagerment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FunnyCafeManagermentFunnyCafeManagerment  5   	   '    !FunnyCafeManagerment.ForgetWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:FunnyCafeManagerment     5   	     � Title$  Forget password?��5   	   $	��200��6"   $	��450��6/    � WindowStartupLocation$ CenterScreen=�6;    � AllowsTransparency$
 True��5	   	   
������  � Icon$ Images/coffee-cup.ico��5   	    � WindowStyle$
 None=�5   	    � 	Resources 5       �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� CornerRadius �� 
BottomLeft �� BottomRight �� TopLeft �� TopRight��%%  '�       �� 5   
   " �6   .�5      ��  � �� 5      �� 5      "	 �6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   
 5      �� 5   "   $ 20Q�6/   $ 20Q�6?   $ 20Q�6P   $ 20Q�6]   ._�5      �� 5      5      5      5      5      .��5!      � .+�5#   
   �� 
���**��$��40��6$   $	��Top=�60   $
 	20,20,0,0��6H   ._�5$      � .+�5&      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   $
��Left=�6Q   $��10,0,0,0q�6l   .+�5'      �� $��Images/coffee-cup.ico��6   $��24��6;   $��24��6F   �� 5)      $��Forget password?��6    
�������$��16(�6K   $��Center=�6Y   $��10,0,0,0q�6t   5*      �� 5-      $ 
Horizontal=�6   $��Right=�66   $��Center=�6R   $��0,0,10,0q�6m   .+�5/      �� -   5        $��_��5/      $��30��6)   $��30��64      WindowButtonStyle#��[  6]   �� 51      -   5        $��X��51      $��30��6)   $��30��64     CloseButtonStyle#��[ 6Z   52      53      54      �� 55   
   
��� ���$
 	0,0,20,20��6%   
�������$��1q�6Q   $��0,40,0,0q�6e   ._�57      � $��-1,-1,-1,-1q�6   ��59      �� 5:       �� ImageSource$! Images/login_background.png��6!    � ColumnDefinitions 5>      �� 5?      $��* �6'   �� 5@      $��* �6'    � RowDefinitions 5D      �� 5E      $
��Auto �6$   �� 5F      $
��Auto �6$   �� 5G      $
��Auto �6$   .+�5K      �� 
�������$��Enter your email:��5M      $��Center=�5N      $��Center=�5O      $��20(�5P      $��2��5Q      $��	0,20,0,10q�5R        CustomFont2#��[ 5S      �� 5V        TextBoxStyle#��[ 6   $	��360��5W      $��35��5X      $
��Left=�5Y      $	��Top=�5Z      $��20(�5[      $��2��5\      $��	15,69,0,0q�5]      $��3��6(   �� 5a      -   5         ��Name$ SendEmailButton��5a        ButtonStyle#��[ 5b      $��48��5d      $��35��5e      ���#0866FF
�������$
��Bold"�5h      $
��20px(�5i      $
��Left=�5j      $	��Top=�5k      $��
159,69,0,0q�5l      $��1��6)   $��3��69   .��5m      �� $��Images/send.png��6   $��29��65   $��28��6A   5n      5o      5p      5q      5r      