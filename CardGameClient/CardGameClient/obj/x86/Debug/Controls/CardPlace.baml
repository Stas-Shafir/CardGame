   M S B A M L   `   `   `  ����I  ECardGameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CardGameClientCardGameClient  5          CardGameClient.CardPlace   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +dcclr-namespace:CardGameClient     5      -   5        .��5	      � -   5        $��GridMain��5	      $��0q�6     J� Opacity$  1Q�6&   .+�5   
   �� -   5        $��
borderGrid��5   %   $y�Hidden=�6   $��-7q�67   $��2q�6C   ���	#FFC1C1C1 �� CornerRadius$ 7��6o   5      � 5   
   -   5        $��CardCrid��5      $y�Hidden=�6   }�.   K� ZIndex$ 0��6H   .+�5      �� -   5        $��Portrait��5   ;    �� BitmapScalingMode$
 Fant=�6   $
��Fill=�6K   $y�Visible=�6Z   $ 0��6o   �� 5      -   5        $��	borderImg��5   "   $
��-0.5q�6   $R��Lpack://application:,,,/CardGameClient;component/Images/cardmin_my_border.png��63   $
��Fill=�6�   � 5      $
��Left=�6   $��Bottom=�6.   $��	10,0,0,60q�6I   .+�5      �� -   5        $��	AttackBar��5      $K��Epack://application:,,,/CardGameClient;component/Images/attackIkon.png��6)   $
 Fant=�6x   $
��Fill=�6�   $
��Left=�6�   $��19��6�   $��20��6�   $��Center=�6�   $y�Visible=�6�      CardGameClient.Digit  5      -   5          Name$ AttakDig��5      $
��Left=�6-   $	��Top=�6H   $��18,0,0,0q�6`   $y�Visible=�6r   5      � 5      $
��Left=�6   $��Bottom=�6.   $��	10,0,0,35q�6I   .+�5      �� -	   5        $��DefBar��5      $H��Bpack://application:,,,/CardGameClient;component/Images/defIkon.png��6&   $
 Fant=�6r   $
��Fill=�6�   $
��Left=�6�   $��19��6�   $��20��6�   $��Center=�6�   $y�Visible=�6�     5      -
   5        $ DefDig��5      $
��Left=�6+   $	��Top=�6F   $��18,0,0,0q�6^   $y�Visible=�6p   5      � 5      $
��Left=�6   $��Bottom=�6.   $��	10,0,0,10q�6I   .+�5       �� -   5        $��HpBar��5       $E��?pack://application:,,,/CardGameClient;component/Images/shar.png��6%   $
 Fant=�6n   $
��Fill=�6�   $
��Left=�6�   $��19��6�   $��20��6�   $��Center=�6�   $y�Visible=�6�     5!      -   5        $ HpDig��5!      $
��Left=�6*   $	��Top=�6E   $��18,0,0,0q�6]   $y�Visible=�6o   5"      �� 5$      -   5        $��dmgLabel��5$   2   $��55��6   $��0,6,6,0q�6!   $	��Top=�6B   
���  ��$��32(�6k   $��Normal"�6y   $��Right=�6�   $��LeftToRight=�6�   $��Verdana)�6�   $  0Q�6�   ��5%      �� 5&       �� ImageSource$9 3/CardGameClient;component/Images/dmg_label_back.png��6!    j� Stretch$
 Fill=�6c   5(      �� 5*      -   5        $��dmgLabeladtnl��5*   8   $��	Крит!��6   $��
0,35,-15,0q�6$   $	��Top=�6M   
���  ��$��16(�6v   $��Normal"�6�   $��Right=�6�   $��LeftToRight=�6�   $��Verdana)�6�   $  0Q�6�   ��5+      �� 5,      $9 3/CardGameClient;component/Images/dmg_label_back.png��6!   $
 Fill=�6c   5.      �� 50      -   5        $��dmgImgEffect��50      $6��0/CardGameClient;component/Images/Effects/dmg.png��6(   $��80��6b   $��Center=�6m   $��Center=�6�   $  0Q�6�   �� 52      -   5        $��InjuryEffect��52      $y�Hidden=�6(   $
��Left=�6<   $	��Top=�6W   $��
7, 7, 0, 0q�6o   $��25��6�   $��25��6�   $9��3/CardGameClient;component/Images/Effects/injury.png��6�    � ToolTip 53      _� 54      -   5        $��InjuredToolTip��54      $��2q�64   $��Center=�6@   ���	#DD000000
�������$��0q�6�   
���   �6�   56      57         CardGameClient.sellmenu  59   
   -   5          Name$ sellBtn��59         CardGameClient.sellmenu	   MouseUp$	 sellBtn_MouseUp_1��6�   $��Center=�6'   $��Center=�6D   $��15, 0, 0, 0q�6`   $y�Hidden=�6u   {�.  6�   ��5;   
   �� 5<      $8 2/CardGameClient;component/Images/cardmin_my_bg.png��6   5?      5@      