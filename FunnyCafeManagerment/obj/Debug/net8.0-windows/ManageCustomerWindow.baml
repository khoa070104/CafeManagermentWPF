   M S B A M L   `   `   `  ����  FunnyCafeManagerment/    )FunnyCafeManagerment.ManageCustomerWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  ManageCustomerWindow��5   	   $	��650��5   	   $
��1000��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	   
������  � 
ResizeMode$ NoResize=�5   	    � 	Resources 5       �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� CornerRadius �� 
BottomLeft �� BottomRight �� TopLeft �� TopRight��%  '�       �� 5   
   " �6   .�5      ��  � �� 5      �� 5      "	 �6&   .R�5      �� #��z��6!   #��z��5   !   $��1q�5   !   
 5      �� 5   "   $ 20Q�6/   $ 20Q�6?   $ 20Q�6P   $ 20Q�6]   5      5      5      5       5!      .��5$      �� 
�������$
 20��6    
�������$��1q�6E   ._�5%   
   � .+�5'      �� 
���**��$��40��6(   $	��Top=�64   $
 	20,20,0,0��6L   ._�5(      � .+�5*      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $
��Left=�6U   $��10,0,0,0q�6p   .+�5+      �� $��Images/coffee-cup.ico��6    $��24��6?   $��24��6J   �� 5-      $��Mangage Customer��6$   
�������$��16(�6O   $��Center=�6]   $��10,0,0,0q�6x   5.      �� 51      $ 
Horizontal=�6!   $��Right=�6:   $��Center=�6V   $��0,0,10,0q�6q   .+�53      �� -   5        $��-��53   !   $��30��6-   $��30��68      WindowButtonStyle#��[  6a   �� 55      -   5        $	��□��55   !   $��30��6-   $��30��68   #��[  6a   �� 57      -   5        $��X��57   !   $��30��6-   $��30��68   
�������  CloseButtonStyle#��[ 6q   58      59      5:      � 5=      $��0,40,0,0q�6   .+�5>      � .+�5@      � ���#FCEFE8$��50��60   $	��Top=�6<    � ColumnDefinitions 5A      �� 5B      $
��Auto �6/   �� 5C      $��* �6/   �� 5D      $
��Auto �6/   .+�5H      �� -   5        
������ $��0q�5H   :   $��35��6N   $��35��6Y   $��5q�6e   .��5I      �� $��30��6%   $��30��60   $
 20��6<   ���#D7B08F$��Center=�6c   $��Center=�6~   ._�5J   "   �� $��<��6,   $��16(�68   
�������$��Center=�6Y   $��Center=�6t   $��24��6�   5K      5L      �� 5O      $��1��6!   $��Coffee Shop��61   ���#D7B08F$��20(�6\   $
��Left=�6j   $��10,0,0,0q�5P      $��Center=�6   $��0q�6.   $
��Bold"�5Q      
������ 6   �� 5S      $��2��6%   $ 
Horizontal=�65   $��Center=�6N   $��0,0,10,0q�6i   .+�5U      �� $��Nguyen Van A��6(   $��20(�6<   ���#D7B08F$��Center=�6_   $��0,0,5,0q�6z   �� 5W      $
��👤��6%   $��20(�69   $��0q�6G   ���#D7B08F
������ 6p   5X      5Y      � 5\      $��0,60,0,0q�6    � RowDefinitions 5]      �� 5^      $
��Auto �6,   �� 5_      $��* �6,   .+�5b      � $��10q�6    5d      �� 5e   "   $
��Auto �63   �� 5g   "   $��* �63   .+�5l      �� $��Khách hàng��6(   $��16(�6:   $
��Bold"�6H   ���#D7B08F$��Center=�6o   $
��10,0q�6�   �� 5o      $��1��6)   $��50��69   $	��400��6E   $ 
Horizontal=�6Q   $��Right=�6j   $��Center=�6�   .+�5p   "   �� $
 15��6)   $��30��6;   ���#D8B694$��1q�6]   ���#FCEFE8 �� Padding$ 5q�6�   $��Center=�6�   ._�5q   &   �� $ 
Horizontal=�61   $��Center=�6J   .+�5r   *   �� -   5        $��searchTextBox��5r   q   $	��300��62   $��30��6>   $��Center=�6J   $��5q�6e   $��Tìm kiếm��6�   
�������$��0q�5s   X   
������ 6l   �� 5t   *   $��30��61   $��30��6<   $
��🔎��6H   $��Center=�6\   $��0q�6w   
������ 6�   5u   '   5v   #   �� 5y   "   -   5        $��40��5y   )   $��40��64   $	��➕��6@   $��0q�6S   ���#D8B694
�������$��10,0,0,0q�5z   	   $��Center=�6   $��Right=�66   $��18(�6R   $
��Bold"�6`    J� Clip 5{   &   @� 5|   *    @� RadiusX$ 20Q�6:    @� RadiusY$ 20Q�6G    @� Center$ 20,20&�6T   ��5�   &   �� 5�   *   "	 ��6:   .R�5�   .   ��  ��Name$ border��65   #��z��6E   #��z��5�      $
 20��5�      ._�5�   2   �� $��Center=�6C   $��Center=�6`   5�   /    �� Triggers 5�   .   P� 5�   2    P� Property �@J�IsMouseOver P� Value$
 True��6Q   . �5�   6   ��  �� 
TargetName$ border��6=    � �� �#B088666g   5�   3   5�   +   ��5�   &   �� 5�   *   " ��60   .�5�   .   ��  � �� �#D8B6946K   �� 5�   .    � ��
 �����6K   �� 5�   .    �@�Cursor$
 Hand��6G   5�   +   5�   #   5�      5�      �� 5�      $��1��6!   $��20q�6.   ���#D8B694$��2q�6P   $
 20��6d   $ 10q�6v   
�������._�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ customerDataGrid��5�   '      AutoGenerateColumns$ False��5�         CanUserAddRows$ False��5�         HeadersVisibility$ Column=�5�      $��14(�5�      
�������$��0q�5�          RowBackground
  �����!   AlternatingRowBackground
! �����"   GridLinesVisibility$
" None=�5�        CustomColumnHeaderStyle#   ColumnHeaderStyle## [ 5�        CustomRowStyle$   RowStyle#$ [ 5�      ��5�      �� *	customers+%   Columns% 5�   "   0  *System.Windows.Controls.DataGridTextColumn  5�   &   ,  &System.Windows.Controls.DataGridColumn&   Header$& ID��69   '   Width5  /System.Windows.Controls.DataGridLengthConverter$
' auto 6E   1  +System.Windows.Controls.DataGridBoundColumn(   Binding( 6R   �� *ID+)   ElementStyle) 5�   *   �� 5�   .   * �� ResourceKey$* CenterAlignedTextBlock��6=   5�   '     5�   &   $& Tên khách hàng��69   $' * 6Q   ( 6[   �� *TenKhachHang+) 5�   *   �� 5�   .   $* CenterAlignedTextBlock��6=   5�   '     5�   &   $& Số điện thoại��69   $
' auto 6P   ( 6]   �� *SoDienThoai+) 5�   *   �� 5�   .   $* CenterAlignedTextBlock��6=   5�   '     5�   &   $& Email��69   $	' 200 6H   ( 6T   �� *Email+) 5�   *   �� 5�   .   $* CenterAlignedTextBlock��6=   5�   '     5�   &   $& 	Chi tiêu��69   $	' 100 6K   ( 6W   �� *	ChiTieu+) 5�   *   �� 5�   .   $* CenterAlignedTextBlock��6=   5�   '     5�   &   $& Ghi chú��69   $' * 6J   ( 6T   �� *GhiChu+) 5�   *   �� 5�   .   $* CenterAlignedTextBlock��6=   5�   '   4  .System.Windows.Controls.DataGridTemplateColumn  5�   &   $& Actions��6=   $' * 6N   +   CellTemplate+ 5�   *   �� 5�   .   .R�5�   2   �� $ 
Horizontal=�6=   $��Center=�6V   .+�5�   6   �� -   5        $	��✎��5�   =   $��16(�6P   $��30��6^   $��30��6i   $��5,0,0,0q�6u   
������ $��0q�5�   "   $��0q�66   , � ToolTip$
, Edit��5�   	   ��5�   :   �� 5�   >   " ��6D   .�5�   B   ��  � �� �#FF884D6_   �� 5�   B    �@�Cursor$
 Hand��6[   5�   ?   5�   7   �� 5�   6   -	   5        $
��🗑��5�   =   $��16(�6Q   $��30��6_   $��30��6j   $��5,0,0,0q�6v   
������ $��0q�5�   "   $��0q�66   $, Delete��5�   	   ��5�   :   �� 5�   >   " ��6D   .�5�   B   ��  � �� �#00AEEF6_   �� 5�   B    �@�Cursor$
 Hand��6[   5�   ?   5�   7   5�   3   5�   /   5�   '   5�      5�      5�      5�      5�      � 5�      -
   5        - �Name$- 
DeleteForm��5�      $y�	Collapsed=�6'   
������ $	��400��6W   $	��300��6c   $��Center=�6p   $��Center=�6�   .+�5�      �� 
�������$
 20��6,   
�������$��1q�6Q   ._�5�      � 
������ .+�5      �� 
���**��$��40��64   $	��Top=�6@   $
 	20,20,0,0��6X   ._�5     � .+�5  "   �� $ 
Horizontal=�6-   $��Center=�6F   $
��Left=�6a   $��10,0,0,0q�6|   .+�5  &   �� $��Images/coffee-cup.ico��6,   $��24��6K   $��24��6V   �� 5  &   $��Warning��60   
�������$��16(�6R   $��Center=�6`   $��10,0,0,0q�6{   5  #   �� 5	  "   $ 
Horizontal=�6-   $��Right=�6F   $��Center=�6b   $��0,0,10,0q�6}   .+�5
  &   �� -   5        $��X��5
  -   $��30��69   $��30��6D   
�������#��[ 6�   5  #   5     5     � 5     $��0,40,0,0q�6   
������ .+�5     �� $��Center=�6)   $��Center=�6F   $��20q�6a   .+�5  "   �� $ Vertical=�6-   $��Center=�6D   .+�5  &   �� $��⚠️��60   $��40(�6:   
���  ��$��Center=�6Y   5  #   �� 5  "   $1��+Bạn có chắc chắn muốn xóa không?��6,   $��16(�5     $
��Bold"�5     
���   �$��Center=�5     $��10q�5     �� 5  "   $ 
Horizontal=�6-   $��Center=�6F   $��10q�6c   .+�5  &   �� -   5        $	��Có��5  -     ButtonStyle#��[ 6:   $
��Bold"�6_   $	��100��6q   $��30��6}   ���#63A8D8
�������$
��10,0q�6�   ��5  *   �� 5   .   "	 ��6>   .R�5!  2   �� $
 15��69   #��z��6K   
������ $��0q�6�   . J� Effect. 5"  6   3  -System.Windows.Media.Effects.DropShadowEffect  5#  :   /   ShadowDepth$/ 3Q�6K   0   
BlurRadius$0 10Q�6[   1   Opacity$	1 0.5Q�6k   ._�5%  6   �� $��Center=�6G   $��Center=�6d   5&  3   5'  /   5)  '   �� 5+  &   -   5        $��Không��5+  -   #��[ 6=   $
��Bold"�6b   $	��100��6t   $��30��6�   ���#E85350
�������$
��10,0q�6�   $��Right=�6�   ��5,  *   �� 5-  .   "	 ��6>   .R�5.  2   �� $
 15��69   #��z��6K   
������ $��0q�6�   . 5/  6     50  :   $/ 3Q�6K   $0 10Q�6[   $	1 0.5Q�6k   ._�52  6   �� $��Center=�6G   $��Center=�6d   53  3   54  /   56  '   57  #   58     59     5:     5;     5<     � 5>     -   5        $- AddForm��5>     $y�	Collapsed=�6$   
������ $	��600��6T   $	��450��6`   $��Center=�6m   $��Center=�6�   .+�5?     �� 
�������$
 20��6,   
�������$��1q�6Q   ._�5@     � .+�5B     �� 
���**��$��40��64   $	��Top=�6@   $
 	20,20,0,0��6X   ._�5C     � .+�5E  "   �� $ 
Horizontal=�6-   $��Center=�6F   $
��Left=�6a   $��10,0,0,0q�6|   .+�5F  &   �� $��Images/coffee-cup.ico��6,   $��24��6K   $��24��6V   �� 5H  &   $��Add Customer��60   
�������$��16(�6W   $��Center=�6e   $��10,0,0,0q�6�   5I  #   �� 5L  "   $ 
Horizontal=�6-   $��Right=�6F   $��Center=�6b   $��0,0,10,0q�6}   .+�5N  &   �� -   5        $��X��5N  -   $��30��69   $��30��6D   
�������#��[ 6}   5O  #   5P     5Q     � 5R     $��0,40,0,0q�6   .+�5S     �  5T  "   �� 5U  &   $
��Auto �64   �� 5V  &   $��* �64   �� 5W  &   $
��Auto �64   .+�5[  "   �� $��Thêm khách hàng��6,   $��20(�6C   $
��Bold"�6Q   $��Center=�6c   ���#DD702E$��	0,20,0,10q�6�   � 5^  "   $��1��6'   $��0,0,0,0q�64    5`  &   �� 5a  *   $��1* �6;   �� 5b  *   $��1* �6;   .+�5f  &   �� $��0��61   $��10q�6A   .+�5g  *   �� $��	Họ tên��64   $��Italic$�6B   $
��Bold"�6U   �� 5h  *   ���#F5F5F5$��1q�6F   $
 10��6Z   $ 5q�6l   $��0,5,0,20q�6x   
���   �._�5i  .   �� -   5        2 ��Name$2 HoTenTextBox��5i  6   $��Center=�6L   $��Center=�6g   $��30��6�   
������ $��0q�6�   $��Nhập họ tên��6�   
�������5j  D   5k  +   �� 5n  *   $��Email��64   $��Italic$�6A   $
��Bold"�6T   �� 5o  *   ���#F5F5F5$��1q�6F   $
 10��6Z   $ 5q�6l   $��0,5,0,20q�6x   
���   �._�5p  .   �� -   5        $2 EmailTextBox��5p  6   $��Center=�6L   $��Center=�6g   $��30��6�   
������ $��0q�6�   $��Nhập email��6�   
�������5q  D   5r  +   �� 5u  *   $��	Chi tiêu��64   $��Italic$�6D   $
��Bold"�6W   �� 5v  *   ���#F5F5F5$��1q�6F   $
 10��6Z   $ 5q�6l   $��0,5,0,20q�6x   
���   �._�5w  .   �� -   5        $2 ChiTieuTextBox��5w  6   $��Center=�6N   $��Center=�6i   $��30��6�   
������ $��0q�6�   $��Nhập chi tiêu��6�   
�������5x  D   5y  +   5z  '   �� 5}  &   $��1��61   $��10q�6A   .+�5  *   �� $��Số điện thoại��64   $��Italic$�6I   $
��Bold"�6\   �� 5�  *   ���#F5F5F5$��1q�6F   $
 10��6Z   $ 5q�6l   $��0,5,0,20q�6x   
���   �._�5�  .   �� -   5        $2 SoDienThoaiTextBox��5�  6   $��Center=�6R   $��Center=�6m   $��30��6�   
������ $��0q�6�   $!��Nhập số điện thoại��6�   
�������5�  D   5�  +   �� 5�  *   $��Ghi chú��64   $
��Bold"�6C   ���#DD702E6U   �� 5�  *   $��1��61   $��0,10,0,0q�6>   ���#D8B694$��2q�6f   $
 20��6z   $ 10q�6�   
�������._�5�  .   �� ���#DDDDDD$
 10��6J   $ 5q�6\   ._�5�  2   �� -   5        $2 GhiChuTextBox��5�  :   $��Nhập ghi chú��6Q   $��90��6e   3 �� AcceptsReturn$
3 True��6q   
������ $��0q�6�   
�������5�  6   5�  /   5�  +   5�  '   5�  #   �� 5�  "   $��2��6-   $ 
Horizontal=�6:   $��Center=�6S   $��0,0,0,40q�6p   .+�5�  &   �� -   5        $��Thêm��5�  -   #��[ 6<   $
��Bold"�6a   $	��100��6s   $��30��5�  !   ���#D7B08F
�������$
��10,0q�6U   ��5�  *   �� 5�  .   "	 ��6>   .R�5�  2   �� $
 15��69   #��z��6K   
������ $��0q�6�   . 5�  6     5�  :   $/ 5Q�6K   $0 10Q�6[   $	1 0.5Q�6k   ._�5�  6   �� $��Center=�6G   $��Center=�6d   5�  3   5�  /   5�  '   �� 5�  &   -   5        $��Bỏ qua��5�  -   #��[ 6>   $
��Bold"�6c   $	��100��6u   $��30��6�   ���#E0E0E0
���   �$
��10,0q�6�   ��5�  *   �� 5�  .   "	 ��6>   .R�5�  2   �� $
 15��69   #��z��6K   
������ $��0q�6�   . 5�  6     5�  :   $/ 5Q�6K   $0 10Q�6[   $	1 0.5Q�6k   ._�5�  6   �� $��Center=�6G   $��Center=�6d   5�  3   5�  /   5�  '   5�  #   5�     5�     5�     5�     5�     � 5�     -   5        $- EditForm��5�     $y�	Collapsed=�6%   
������ $	��600��6U   $	��450��6a   $��Center=�6n   $��Center=�6�   .+�5�     �� 
�������$
 20��6,   
�������$��1q�6Q   ._�5�     � .+�5�     �� 
���**��$��40��64   $	��Top=�6@   $
 	20,20,0,0��6X   ._�5�     � .+�5�  "   �� $ 
Horizontal=�6-   $��Center=�6F   $
��Left=�6a   $��10,0,0,0q�6|   .+�5�  &   �� $��Images/coffee-cup.ico��6,   $��24��6K   $��24��6V   �� 5�  &   $��Edit Customer��60   
�������$��16(�6X   $��Center=�6f   $��10,0,0,0q�6�   5�  #   �� 5�  "   $ 
Horizontal=�6-   $��Right=�6F   $��Center=�6b   $��0,0,10,0q�6}   .+�5�  &   �� -   5        $��X��5�  -   $��30��69   $��30��6D   
�������#��[ 6~   5�  #   5�     5�     � 5�     $��0,40,0,0q�6   .+�5�     �  5�  "   �� 5�  &   $
��Auto �64   �� 5�  &   $��* �64   �� 5�  &   $
��Auto �64   .+�5�  "   �� $��Sửa khách hàng��6,   $��20(�6B   $
��Bold"�6P   $��Center=�6b   ���#DD702E$��	0,20,0,10q�6�   � 5�  "   $��1��6'   $��0,0,0,0q�64    5�  &   �� 5�  *   $��1* �6;   �� 5�  *   $��1* �6;   .+�5�  &   �� $��0��61   $��10q�6A   .+�5�  *   �� $��	Họ tên��64   $��Italic$�6B   $
��Bold"�6U   �� 5�  *   ���#F5F5F5$��1q�6F   $
 10��6Z   $ 5q�6l   $��0,5,0,20q�6x   
���   �._�5�  .   �� -   5        $2 EditHoTenTextBox��5�  6   $��Center=�6P   $��Center=�6k   $��Nguyễn Văn B��6�   $��30��6�   
������ $��0q�6�   5�  +   �� 5�  *   $��Email��64   $��Italic$�6A   $
��Bold"�6T   �� 5�  *   ���#F5F5F5$��1q�6F   $
 10��6Z   $ 5q�6l   $��0,5,0,20q�6x   
���   �._�5�  .   �� -   5        $2 EditEmailTextBox��5�  6   $��Center=�6P   $��Center=�6k   $��nguyenvanb@gmail.com��6�   $��30��6�   
������ $��0q�6�   5�  +   �� 5�  *   $��	Chi tiêu��64   $��Italic$�6D   $
��Bold"�6W   �� 5�  *   ���#F5F5F5$��1q�6F   $
 10��6Z   $ 5q�6l   $��0,5,0,20q�6x   
���   �._�5�  .   �� -   5        $2 EditChiTieuTextBox��5�  6   $��Center=�6R   $��Center=�6m   $��2,000,000 VNĐ��6�   $��30��6�   
������ $��0q�6�   5�  +   5�  '   �� 5�  &   $��1��61   $��10q�6A   .+�5�  *   �� $��Số điện thoại��64   $��Italic$�6I   $
��Bold"�6\   �� 5�  *   ���#F5F5F5$��1q�6F   $
 10��6Z   $ 5q�6l   $��0,5,0,20q�6x   
���   �._�5�  .   �� -   5        $2 EditSoDienThoaiTextBox��5�  6   $��Center=�6V   $��Center=�6q   $��01234567890��6�   $��30��6�   
������ $��0q�6�   5�  +   �� 5�  *   $��Ghi chú��64   $
��Bold"�6C   ���#DD702E6U   �� 5�  *   $��1��61   $��0,10,0,0q�6>   ���#D8B694$��2q�6f   $
 20��6z   $ 10q�6�   
�������._�5�  .   �� ���#DDDDDD$
 10��6J   $ 5q�6\   ._�5�  2   �� -   5        $2 EditGhiChuTextBox��5�  :   $��Ghi chú��6U   $��90��6d   $
3 True��6p   
������ $��0q�6�   5�  /   5   +   5  '   5  #   �� 5  "   $��2��6-   $ 
Horizontal=�6:   $��Center=�6S   $��0,0,0,40q�6p   .+�5  &   �� -   5        $��Sửa��5  -   #��[ 6;   $
��Bold"�6`   $	��100��6r   $��30��6~   ���#D7B08F
�������$
��10,0q�5  4   ��5
  *   �� 5  .   "	 ��6>   .R�5  2   �� $
 15��69   #��z��6K   
������ $��0q�6�   . 5  6     5  :   $/ 5Q�6K   $0 10Q�6[   $	1 0.5Q�6k   ._�5  6   �� $��Center=�6G   $��Center=�6d   5  3   5  /   5  '   �� 5  &   -   5        $��Bỏ qua��5  -   #��[ 6>   $
��Bold"�6c   $	��100��6u   $��30��6�   ���#E0E0E0
���   �$
��10,0q�5  4   ��5  *   �� 5  .   "	 ��6>   .R�5  2   �� $
 15��69   #��z��6K   
������ $��0q�6�   . 5  6     5  :   $/ 5Q�6K   $0 10Q�6[   $	1 0.5Q�6k   ._�5!  6   �� $��Center=�6G   $��Center=�6d   5"  3   5#  /   5%  '   5&  #   5)     5*     5+     5,     5-     � 5/      51     �� 52     $
��Auto �6'   �� 54     $��* �6'   .+�58     � -    5        $- SidebarForm��58     ���#FCEFE8$	��240��6A   $	��610��6M   $
��Left=�6Z   $��Center=�6u   $y�	Collapsed=�6�   $��0,40,0,0q�6�   .+�59     �� $
��Left=�6!   $	��Top=�6<   $	��200��6T   $��20,0,0,0q�6`   .+�5;     �� $ 
Horizontal=�6%   $��	20,0,0,20q�6>   .+�5<     �� $��Coffee Shop��6(   $��20(�6;   $
��Bold"�6I   ���#D7B08F$��Center=�6p   �� 5>     -!   5        
������ $��0q�5>  >   $��35��6R   $��35��6]   $��5q�6i   .��5?  "   �� $��30��6)   $��30��64   $
 20��6@   ���#D7B08F$��Center=�6g   $��Center=�6�   ._�5@  &   �� $��>��60   $��16(�69   
�������$��Center=�6Z   $��Center=�6u   $��24��6�   5A  #   5B     5C     �� 5F     -"   5        $��Sản phẩm��5F  !   
4 � Tag$
4 📦��64     SidebarButtonStyle#��[ 6=   6i   �� 5G     -#   5        $��Nhân viên��5G  !   $
4 👤��65   #��[ 6E   6q   �� 5H     -$   5        $
��Bàn��5H  !   $
4 🍽��6/   #��[ 6?   6k   �� 5I     -%   5        $��Khách hàng��5I  !   $
4 👤��66     ProductButtonStyle#��[ 6F   6r   �� 5J     -&   5        $��Thống kê��5J  !   $
4 📊��64   #��[ 6=   6i   �� 5K     -'   5        $��	Sự cố��5K  !   $	4 ⚠��61   #��[ 6@   6l   5L     5M     � 5O     -(   5        $- RightOverlay��5O     $��1��6-   
������ $y�	Collapsed=�6V   $��0,40,0,0q�5P     .+�5R     �� -)   5        5 ��Name$5 DimBackground��5R      
���   �6 J� Opacity$6 0Q�6D   7 J� IsHitTestVisible$7 False��6P   �� 5U     -*   5        8 ��Name$8 MainContentPresenter��5U  '   ��6E   �� 5V     5X     5Y     5Z     5[     