   M S B A M L   `   `   `  ����I  ECardGameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CardGameClientCardGameClient  5   	        CardGameClient.LoginScreen   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   +dcclr-namespace:CardGameClient     5   	   -   5        $��LoginWnd��5   +     � Title$  Avalon: Battles for Glory��6	   $	��768��6;   $
��1024��6K   $	��768��6[   $
��1024��6h    � Cursor$1 +/CardGameClient;component/Images/cursor.cur��6u    � WindowStyle$
 None=�6�    � WindowStartupLocation$ CenterScreen=�6�    � 
ResizeMode$ NoResize=�6�    � WindowState$ 	Maximized=�6�   .��5      �  �� BitmapScalingMode$
 Fant=�6   ��5   
   �� 5       �� ImageSource$: 4/CardGameClient;component/Images/Background/bg03.jpg��6    j� Stretch$ UniformToFill=�6\   .+�5
   
   � -   5        $��grid1��5
   9   $	��230��6   $��Center=�6   $��Center=�6F   $	��395��6a   ��5      �� 5      $5 //CardGameClient;component/Images/login_form.png��6   .+�5      �� -   5        $��LoginErrorInfo��5      $��Center=�6*   $��0, 20, 0, 0q�6G   $	��Top=�6\   
���  ��$�� ��6�   �� 5      -   5        $��loginTextBox��5   d   $
��Left=�6   $�� ��61   $��
5, 3, 3, 5q�69   $��166,56,0,148q�6N   $	��150��6x   
�������$��0��6�   $��0q�6�   	 J� SnapsToDevicePixels	 . $��13(�6�   
 �� TextAlignment$
 Justify=�6�   $��Tahoma)�6�    �� 
CaretBrush
 �����.��6%  ��5      �� 5      $2 ,/CardGameClient;component/Images/textbox.png��6!   .��5   &   5      G� 5      -   5        $��passwordTextBox��5   j   $��26��6   $
��Left=�6&   $��
5, 7, 7, 5q�6A   $��
166,96,0,0q�6V   $	��Top=�6�   $	��150��6�   
�������$��1��6�   $��0q�6�   $��13(�6�   $��Tahoma)�6�    G� PasswordChar$ *��6�    G� 
CaretBrush
 �������5      �� 5      $2 ,/CardGameClient;component/Images/textbox.png��6!   5      �� 5      -   5        $��
login_text��5   u   $
 Fant=�6   $��25��6;   $
��Left=�6G   $��	88,57,0,0q�6b   $	��Top=�6�   $��71��6�   $5��//CardGameClient;component/Images/login_text.png��6�   �� 5      -   5        $��password_text��5   u   $
 Fant=�6   $��25��6;   $
��Left=�6G   $��	77,97,0,0q�6b   $	��Top=�6�   $��82��6�   $8��2/CardGameClient;component/Images/password_text.png��6�      CardGameClient.StyledBtn  5      -   5          Name$ loginBtn��5         CardGameClient.StyledBtn   MouseUp$ loginBtn_MouseUp��6g      Text$ 
Войти��6-   $��34��6:   $	��130��6F   $��56,156,0,40q�6R   $
��Left=�6�   6�     5      -	   5        $ exitBtn��5      $ exitBtn_MouseUp��6�   $ 
Выйти��6,   $��34��69   $	��130��6E   $��0,156,53,40q�6Q   $��Right=�6f   6�   5      �� 5    
   -
   5        $��LogoImg��5       $	��149��6   $��Center=�6,   $	��Top=�6I   $	��492��6a   $/��)/CardGameClient;component/Images/logo.png��6m   $��0,70,0,0q�6�   � 5!   
   -   5        $��grid2��5!   9   $��38��6   $��Stretch=�6   $��Bottom=�6F   ���	#C5000000.+�5"      �� -   5        $��	errorText��5"      $V��PAvalon: Battles for Glory. Сopyright (c) Шафир Станислав, 2015г ��6%   $
��Auto��6p   $��Center=�6~   $��317,8,317,6q�6�   $��Center=�6�   ���	#FFFCFCFC6�   5#         CardGameClient.PopupInfo  5&   
   -   5          Name$ errorPopupInfo��5&       J� Opacity$ 1Q�6/   $y�Hidden=�6;   5'      5(      