   M S B A M L   `   `   `  ����I  ECardGameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CardGameClientCardGameClient  5   	   %    CardGameClient.GameResultWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   +dcclr-namespace:CardGameClient     5   	   -   5        $��GameResultWnd��5   +     � Title$  Avalon: Battles for Glory��6	    � 
ResizeMode$ NoResize=�6@    � ShowInTaskbar .   � WindowStartupLocation$ CenterScreen=�6l   $	��768��6�   $
��1024��6�   $	��768��6�   $
��1024��6�    � Cursor$1 +/CardGameClient;component/Images/cursor.cur��6�    � WindowStyle$
 None=�6   � WindowState$ 	Maximized=�6   � AllowsTransparency . ���	#C6000000.��5      � $	��311��6   $	��264��6   $	��311��6$   $	��264��64   ��5   
   �� 5       �� ImageSource$5 //CardGameClient;component/Images/newCardWnd.png��6   	 �� BitmapScalingMode$
	 Fant=�6W   .+�5
   
   �� -   5        $��PlaceHolder��5
      $��75��6   $��75��6/   $��Center=�6:   $	��Top=�6W   $1��+/CardGameClient;component/Images/winner.png��6o   $��	0,0,190,0q�6�   �� 5   
   -   5        $��GameResultLabel��5      
 � UseLayoutRounding
 .  J� SnapsToDevicePixels . $��Победа!��6[   $��Center=�6m   $��0,36,0,0q�6�   $��24(�6�   $,��&Fonts/MyriadPro-Regular.otf#Myriad Pro)�6�   $	��Top=�6�   
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 0Q�6#      RenderingBias$ Quality=�62      	Direction$	 330Q�6J      ShadowDepth$ 3Q�6Z   5      �� 5   
   -   5        $��
LevelLabel��5      
 .  . $ ��Новый уровень!��6V   $��Center=�6o   $��0,80,0,0q�6�   $��18(�6�   $,��&Fonts/MyriadPro-Regular.otf#Myriad Pro)�6�   $	��Top=�6�   
������� 5        5      $ 0Q�6#   $ Quality=�62   $	 330Q�6J   $ 3Q�6Z   5      �� 5   
   
 . $��Вы получили:��6)    . $��Center=�6[   $��Center=�6   $��	0,130,0,0q�6�   $��16(�6�   $,��&Fonts/MyriadPro-Regular.otf#Myriad Pro)�6�   $	��Top=�6�   
������� 5        5      $ 0Q�6#   $ Quality=�62   $	 330Q�6J   $ 3Q�6Z   5      �� 5   
   -   5        $��ExpLabel��5      
 . $��Опыт: 264��69    . $��Center=�6h   $��Center=�6�   $��	0,160,0,0q�6�   $��16(�6�   $,��&Fonts/MyriadPro-Regular.otf#Myriad Pro)�6�   $	��Top=�6�   
������� 5        5      $ 0Q�6#   $ Quality=�62   $	 330Q�6J   $ 3Q�6Z   5      �� 5   
   -   5        $��
ScoreLabel��5      $��Очки: 132��6"   
 .  . $��Center=�6j   $��Center=�6�   $��	0,185,0,0q�6�   $��16(�6�   $,��&Fonts/MyriadPro-Regular.otf#Myriad Pro)�6�   $	��Top=�6   
������� 5         5!      $ 0Q�6#   $ Performance=�62   $	 330Q�6N   $ 3Q�6^   5#         CardGameClient.StyledBtn  5$   
      CardGameClient.StyledBtn   MouseUp$ Image_MouseUp��6�   $��Center=�6      Text$ Принять��64   $��Bottom=�6C   $��34��6^   $	��135��6j   $��0,0,0,35q�6v   6�   5%      5&      