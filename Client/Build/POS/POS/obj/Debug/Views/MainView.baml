   M S B A M L   `   `   `  ����>  :POS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:POSPOS  5   	   L HPrism, Version=6.3.0.0, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59:)clr-namespace:Prism.Events;assembly=PrismPrism.Events 5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       POS.MainView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:POS     5   	   AprismEvents)clr-namespace:Prism.Events;assembly=Prism     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5
   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   -   5          �Name$  FirstWindow��5   	    � Title$ MainView��5   	      POS.POSConstants   getScreenHeight#��Z 6      getScreenWidth#��Z 6Q    � WindowState$ 	Maximized=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5      !   POS.multiBindCloneConverter   multiBindCloneConverter  fixedValue0  fixedValue1  fixedValue2  fixedValue3  menuItemsPanel K� IsItemsHost	 A� Columns  menuItemContainerTemplate
 �� 
TargetType �� Property �� Value �� RelativeSource �� AncestorType �� 
TargetType ��Name �� Path �� Orientation �� CanHorizontallyScroll �� CanVerticallyScroll ��Name �� Triggers P� Property P� Value �� 
TargetName  orderItemContainerTemplate �� Padding J� SnapsToDevicePixels  menuOrderItem 	 menuOrderBtn �Name2   +getMenuOrderHeaderDiscardAndTakeOrderHeight1   *getMenuOrderHeaderDiscardAndTakeOrderWidth 
 menuTabItemTemplate ��Name#    menuItemTabBottomStripHeight+!   $menuItemTabBottomConstantStripHeight��%�  &	        &	      &	 ,     &	 E     &	 ^     &	 w     &	 �     &	 �    &	 �    &		 S    &	
 �      5   
   6(   ��5   
   0��6+   ��5   
   1��6+   ��5   
   2��6+   ��5   
   3��6+   �� 5   
   .R�5      A�  . $	 4��6-   5      �� 5   
   "
 ��62   .�5      ��  � ��
 ���� 6+   �� 5        � �� 6;   �� *HorizontalContentAlignment+ �� " ���� 5!       � �� 69   �� *VerticalContentAlignment+ �� " ���� 5"       � ��$ 2,0,0,0q�6(   �� 5#       � ��$ Stretch=�6;   �� 5$       � �� 5%      �� 5&      " ��6&   .R�5'      �� $ Bd��6!   $	��0.8q�6-   
�������
���������6n   �� $3 -(local:POSConstants.getMenuCatalogItemMargin)���6�   �� $2 ,(local:POSConstants.getMenuCatalogItemWidth)���6�   �� $3 -(local:POSConstants.getMenuCatalogItemHeight)�._�5(      �� $ Vertical=�6)    .   .  .+�5)   "   � $	��Top=�6'   ��6?   �� $7 1(local:POSConstants.getMenuCatalogItemHalfHeight)�.+�5*   &   �� $ itemProduct��60   $��Center=�6^   $��Center=�6y   
���   �$��Courier)�6�   $��18(�6�   ��6E   �� *	Product+6�   5+   #   � 5,   "   $��Bottom=�6'   ��6B   �� $7 1(local:POSConstants.getMenuCatalogItemHalfHeight)�.+�5-   &   �� $ 	itemPrice��60   $	��Top=�6Z   $��Center=�6r   
��� E��$��Courier)�6�   $��Medium"�6�   $��22(�6�   ��6C   �� *Price+6�   5.   #   5/      50       51      P� 52       �@J�	IsFocused . . �53   "   �� $ Bd��6)    � ��
 � E��6O   �� 54   "   $ itemProduct��6)    � ��
 �����6X   �� 55   "   $ 	itemPrice��6)    � ��
 �����6V   56      58      5:      5;      �� 5=   
   "
 ��63   .�5>      ��  � ��
 ���� 6+   �� 5?       � �� 6;   �� *HorizontalContentAlignment+ �� " ���� 5@       � �� 69   �� *VerticalContentAlignment+ �� " ���� 5A       � ��$ 2,0,0,0q�6(   �� 5B       � �� 5C      �� 5D      " ��6&   .R�5E      �� $ Bd��6!   #��z��6-   #��z��6Y   #��z��6�   # z��6�    . ._�5F      �� $��0 0 0 1q�6%   
�������#��z��6W   ._�5G   "   �� $ 
Horizontal=�6-   $��	0,20,0,20q�6F    .   .  .+�5H   &   �� $ orderQuantity��60   
���   �$��Courier)�6
  $
��Bold"�6  $��18(�61  ��6G   �� *
Quantity+��6a   �� $9 3(local:POSConstants.getMenuOrderItemQuantityMargin)���6�   �� $8 2(local:POSConstants.getMenuOrderItemQuantityWidth)�61  �� 5I   &   $ orderProduct��60   
���   �$��Courier)�6�   $��18(�6�   ��6F   �� *	Product+��6_   �� $7 1(local:POSConstants.getMenuOrderItemProductWidth)�6�   �� 5J   &   $ 
orderPrice��60   
��� E��$��Courier)�6�   $��Medium"�6�   $��22(�6�   ��6D   �� *Price+��6[   �� $5 /(local:POSConstants.getMenuOrderItemPriceWidth)�6�   5K   #   5L      5M       5N      P� 5O       �@��
IsSelected . . �5P   "   �� $ Bd��6)    � ��
 � E��6O   �� 5Q   "   $ orderQuantity��6)    � ��
 �����6Z   �� 5R   "   $ orderProduct��6)    � ��
 �����6Y   �� 5S   "   $ 
orderPrice��6)    � ��
 �����6W   5T      P� 5U       � {� .  . �5V   "   �� # � ��6?    � ��5W      5Y      5[      5\      �� 5^   
   "
 ��6'   .�5_      ��  � �� 5`      �� 5a      " ��6&   .R�5b      �� $ Border��6!   $��0 0 0 3q�61   
�������$
��auto��6c   $
��auto��6q   $	��Top=�6~   ._�5c      �� #��z��6(   $��4,4,4,4q�6F   $��Courier)�6W   $
��Bold"�6l   $��14(�6~   
��� E��6�   5d       5f      5i      5k      5l      �� 5n   
   "
 ��6%   .�5o      ��  � �� 5p      �� 5q      " ��6&   .R�5r      � $ Border��6   
��� E��#��Z 6F   #��Z 6�   $	��Top=�6�   .+�5s      �� $��2q�6/   $��Center=�6:   $��Center=�6W   ��. 6r   5t       5u      P� 5v       � �� . . �5w   "   �� $ Border��6)    � �� �	#FF534D4D6S   5x      5z      5|      5}      �� 5   
   "
 ��6,   .�5�      ��  � �� 5�      �� 5�      " ��6&   .R�5�      � 
�������.+�5�      �� $ menuItemBottomStrip��6(   
�������#��Z  6R   $
��Auto��6�   $��Bottom=�6�   �� 5�      
��� E��#��Z! 69   $
��Auto��6�   $��Bottom=�6�   �� 5�      #��z��6(   $��Courier)�6H   $
��Bold"�6]   $��14(�6o   
���   �$��Center=�6�   $��Center=�6�   6�   5�       5�      P� 5�       �@��
IsSelected . . �5�   "   �� $ menuItemBottomStrip��6)    � ��
 � E��6Z   5�      5�      5�      5�      5�      " � Triggers" 5�      .��5�      � #��Z 6   #��Z 6B   .+�5�   
   � #   getTitleHeight#��Z# 6   
��� E��$   getTitleWidth#��Z$ 6\   $	��Top=�6�   $��Center=�6�   .+�5�      ]� .+�5�      �� $��/images/title.png��6   %   getTitleLogoHeight#��Z% 63   $��15,3,0,0q�6m   $	��250��6   $
��Left=�6�   $
��Fill=�6�   ]� 5�      #��Z% 6   $��Right=�6V   .+�5�      �� 
�������$��38(�6f   $��Courier)�6t   $��Light"�6�   $��Center=�6�   ��6    �� $ order.numOrders�& �� Mode$& OneWay=�6�   �� 5�      $��/images/exitIcon.png��6   $��20,0,0,0q�6:   .  (System.Windows.Interactivity.Interaction'   Triggers' 5�      /  )System.Windows.Interactivity.EventTrigger  5�      (   	EventName$( MouseUp��6-   .  (System.Windows.Interactivity.TriggerBase)   Actions.) 5�   "   6  0System.Windows.Interactivity.InvokeCommandAction  *   Command* 68   �� *order.exitApplicationICommand+5�      5�      5�      5�      5�      � 5�   
   +   getMenuHeight#��Z+ 6   ,   getMenuWidth#��Z, 6D   $��Bottom=�6w   .+�5�      �� ��5�      �� 5�      - �� ImageSource$- /images/tileSmall.png��6!   . j� TileMode$
. Tile=�6E   / j� ViewportUnits$/ Absolute=�6U   0 j� Viewport$0 	0,0,10,10�6n   1 j� Stretch$1 Uniform=�6�   5�      �� 5�      2   getMenuOrderMargin#��Z2 6   3   getMenuOrderHeight#��Z3 6S   4   getMenuOrderWidth#��Z4 6�   $��Center=�6�   $
��Left=�6�   .+�5�      �� 
�������$��1q�61   � 5�      5   getMenuOrderHeaderHeight#��Z5 6   
��� E��.+�5�      �� $��Order Summary��6    
�������$��	15,0,0,10q�6H   $��36(�6[   $��Courier)�6i   $��Light"�6~   $��Bottom=�6�   $
��Left=�6�   �� 5�      #��[	 6   $	��Top=�6C   $
��Left=�6[   ��6v   �� *" order.removeOrderItemBtnICommand+.��5�      �� $ 
Horizontal=�6%   .+�5�      �� $��Courier)�6(   $��14(�6G   
�������REMOVE6�   �� 5�      $��/images/remove.png��6$   $��15��6@   $��15��6L   $��10,0,0,2q�6W   5�      5�      �� 5�      #��[	 6   $	��Top=�6C   $��Right=�6[   ��6w   �� *order.takeOrderBtnICommand+.��5�      �� $ 
Horizontal=�6%   .+�5�      �� $��Courier)�6(   $��14(�6G   
�������
TAKE ORDER6�   �� 5�      $��/images/check.png��6$   $��15��6?   $��15��6K   $��10,0,0,2q�6V   5�      5�      5�      �� 5�      -   5        6 ��Name$6 sv��5�      !7   getMenuOrderCheckoutHeight#��Z7 6+   ��.  $��Hidden=�6�   $��Disabled=�6�   .��5�      �� -   5        8 ��Name$8 sp��5�   !   
�������' 5�        5�      $( 	MouseMove��6-   .) 5�   "     * 68   �� *order.mouseMoveICommand+9   CommandParameter9 5�   &   `� 5�   *   : `� 	Converter#: [  67   .1�5�   .   ��  66   �� *FindAncestor+$ ScrollViewerL��� 5�   .    66   �� *FindAncestor+$ 
StackPanelL�5�   +   5�   #   5�      .+�5�      �� $��DRINKS��6"   #��[ 60   �� 5�      -   5        ; ��Name$; drinksListBox��5�   "   #��Z4 69   
�������$	��0.5q�6�   #��[ 6�   < �� SelectedIndex< 6q   �� $* $order.menuOrderListsSelectedIndex[0]�$& OneWay=���6-  �� *order.menuOrderLists[0]+' 5�        5�   "   $( MouseUp��61   .) 5�   &     * 6<   �� *#!order.selectedItemChangedICommand+9 5�   *   `� 5�   .   #: [  6;   .1�5�   2   �� = �� Source#= [ 6:   �� 5�   2   $ SelectedIndex�6:   > �� ElementName$> drinksListBox��6O   5�   /   5�   '   5�   #   5�      �� 5�      $��
SANDWICHES��6"   #��[ 64   �� 5�      -   5        $; sandwichesListBox��5�   "   #��Z4 6=   
�������$	��0.5q�6�   #��[ 6�   < 6u   �� $* $order.menuOrderListsSelectedIndex[1]�$& OneWay=���61  �� *order.menuOrderLists[1]+' 5�        5�   "   $( MouseUp��61   .) 5�   &     * 6<   �� *#!order.selectedItemChangedICommand+9 5�   *   `� 5�   .   #: [  6;   .1�5�   2   �� #= [ 6:   �� 5�   2   $ SelectedIndex�6:   $> sandwichesListBox��6O   5�   /   5�   '   5�   #   5�      �� 5�      $��
HAMBURGERS��6"   #��[ 64   �� 5�      -   5        $; hamburgersListBox��5�   "   #��Z4 6=   
�������$	��0.5q�6�   #��[ 6�   < 6u   �� $* $order.menuOrderListsSelectedIndex[2]�$& OneWay=���61  �� *order.menuOrderLists[2]+' 5�        5�   "   $( MouseUp��61   .) 5�   &     * 6<   �� *#!order.selectedItemChangedICommand+9 5�   *   `� 5�   .   #: [  6;   .1�5�   2   �� #= [ 6:   �� 5�   2   $ SelectedIndex�6:   $> hamburgersListBox��6O   5�   /   5�   '   5�   #   5�      �� 5�      $��DESERT��6"   #��[ 60   �� 5�      -   5        $; desertListBox��5�   "   #��Z4 69   
�������$	��0.5q�6�   #��[ 6�   < 6q   �� $* $order.menuOrderListsSelectedIndex[3]�$& OneWay=���6-  �� *order.menuOrderLists[3]+' 5�        5�   "   $( MouseUp��61   .) 5�   &     * 6<   �� *#!order.selectedItemChangedICommand+9 5   *   `� 5  .   #: [  6;   .1�5  2   �� #= [ 6:   �� 5  2   $ SelectedIndex�6:   $> desertListBox��6O   5  /   5  '   5  #   5	     5
     5     � 5     ?   getMenuOrderTotalHeight#��Z? 6   ���	#FF534D4D.+�5     � (@   !getMenuOrderTotalAndSubtotalWidth#��Z@ 6   $
��Left=�6c   $��Center=�6~   .+�5     �� $ Vertical=�6%   .+�5     �� $��Center=�6M   
��� �|�$��Courier)�6�   $��Light"�6�   $��32(�6�   ��6(   �� $ order.Subtotal�6�   �� 5     $��Subtotal��6(   $��Center=�68   
�������$��Courier)�6h   $��
ExtraLight"�6}   $��15(�6�   5     5     � 5     #��Z@ 6   )A   "getMenuOrderTotalAndSubtotalMargin#��ZA 6c   $��Right=�6�   $��Center=�6�   .+�5     �� $ Vertical=�6%   .+�5     �� $��Center=�6J   
��� �|�$��Courier)�6~   $��Light"�6�   $��32(�6�   ��6(   �� $ order.Total�6�   �� 5     $��Total��6(   $��Center=�65   
�������$��Courier)�6e   $��
ExtraLight"�6z   $��18(�6�   5     5     5     5     �� 5     
�������$	��0.5q�6-   B   getMenuItemsMargin#��ZB 6C   C   getMenuItemsHeight#��ZC 6}   D   getMenuItemsWidth#��ZD 6�   $��Center=�6�   $��Right=�6
  ._�5     �� 
�������$	��0.5q�6   < 6   �� $ menu.selectedTabIndex�$& OneWayToSource=�.@�5     �� $��
HAMBURGERS��6   E   getMenuCatalogTabWidth#��ZE 62   F   getMenuCatalogTabHeight#��ZF 6o   #��[
 6�   .��5     �� -   5        $6 menuItemsHamburgersScroll��5  '   ��.  $��Hidden=�6c   $��Hidden=�6�   .��5     �� $ Vertical=�6)   ' 5   $     5!  &   $( 	MouseMove��65   .) 5"  (     * 6>   �� *menu.mouseMoveMenuICommand+9 5#  *   `� 5$  ,   #: [  69   .1�5%  .   ��  66   �� *FindAncestor+$ ScrollViewerL��� 5&  .    66   �� *FindAncestor+$ 
StackPanelL�5'  -   5)  )   5*  '   .+�5,  $   �� -	   5        $; menuItemsHamburgers��5,  ,   $��0q�6�   #��[ 6�   #��[ 6�   G �� SelectedItemG 6I   �� *menu.menuListsSelectedItem[0]+��6  �� *menu.menuItemsLists[0]+' 5-  &     5.  (   $( SelectionChanged��67   .) 5/  .     * 6D   �� *menu.addMenuItemICommand+50  +   52  %   53     54     55     �� 56     $��MEXICAN��6   #��ZE 6/   #��ZF 6l   #��[
 6�   .��57     �� -
   5        $6 menuItemsMexicanScroll��57  '   ��.  $��Hidden=�6`   $��Hidden=�6�   .��58     �� $ Vertical=�6)   ' 59  $     5:  &   $( 	MouseMove��65   .) 5;  (     * 6>   �� *menu.mouseMoveMenuICommand+9 5<  *   `� 5=  ,   #: [  69   .1�5>  .   ��  66   �� *FindAncestor+$ ScrollViewerL��� 5?  .    66   �� *FindAncestor+$ 
StackPanelL�5@  -   5B  )   5C  '   .+�5E  $   �� -   5        $; menuItemsMexican��5E  ,   $��0q�6}   #��[ 6�   #��[ 6�   G 6F   �� *menu.menuListsSelectedItem[1]+��6�   �� *menu.menuItemsLists[1]+' 5F  &     5G  (   $( MouseUp��67   .) 5H  .     * 6D   �� *menu.addMenuItemICommand+5I  +   5K  %   5L     5M     5N     �� 5O     $��
SANDWICHES��6   #��ZE 62   #��ZF 6o   #��[
 6�   .��5P     �� -   5        $6 menuItemsSandwichesScroll��5P  '   ��.  $��Hidden=�6c   $��Hidden=�6�   .��5Q     �� $ Vertical=�6)   ' 5R  $     5S  &   $( 	MouseMove��65   .) 5T  (     * 6>   �� *menu.mouseMoveMenuICommand+9 5U  *   `� 5V  ,   #: [  69   .1�5W  .   ��  66   �� *FindAncestor+$ ScrollViewerL��� 5X  .    66   �� *FindAncestor+$ 
StackPanelL�5Y  -   5[  )   5\  '   .+�5^  $   �� -   5        $; menuItemsSandwiches��5^  ,   $��0q�6�   #��[ 6�   #��[ 6�   G 6I   �� *menu.menuListsSelectedItem[2]+��6  �� *menu.menuItemsLists[2]+' 5_  (     5`  *   $( MouseUp��69   .) 5a  .     * 6D   �� *menu.addMenuItemICommand+5b  +   5d  %   5e     5f     5g     �� 5h     $��	CROISSANT��6   #��ZE 61   #��ZF 6n   #��[
 6�   .��5i     �� -   5        $6 menuItemsCroissantScroll��5i  '   ��.  $��Hidden=�6b   $��Hidden=�6�   .��5j     �� $ Vertical=�6)   ' 5k  $     5l  &   $( 	MouseMove��65   .) 5m  (     * 6>   �� *menu.mouseMoveMenuICommand+9 5n  *   `� 5o  ,   #: [  69   .1�5p  .   ��  66   �� *FindAncestor+$ ScrollViewerL��� 5q  .    66   �� *FindAncestor+$ 
StackPanelL�5r  -   5t  )   5u  '   .+�5w  $   �� -   5        $; menuItemsCroissant��5w  ,   $��0q�6   #��[ 6�   #��[ 6�   G 6H   �� *menu.menuListsSelectedItem[3]+��6   �� *menu.menuItemsLists[3]+' 5x  (     5y  *   $( MouseUp��69   .) 5z  .     * 6D   �� *menu.addMenuItemICommand+5{  +   5}  %   5~     5     5�     �� 5�     $��PANINI��6   #��ZE 6.   #��ZF 6k   #��[
 6�   .��5�     �� -   5        $6 menuItemsPaniniScroll��5�  '   ��.  $��Hidden=�6_   $��Hidden=�6�   .��5�     �� $ Vertical=�6)   ' 5�  $     5�  &   $( 	MouseMove��65   .) 5�  (     * 6>   �� *menu.mouseMoveMenuICommand+9 5�  *   `� 5�  ,   #: [  69   .1�5�  .   ��  66   �� *FindAncestor+$ ScrollViewerL��� 5�  .    66   �� *FindAncestor+$ 
StackPanelL�5�  -   5�  )   5�  '   .+�5�  $   �� -   5        $; menuItemsPanini��5�  ,   $��0q�6|   #��[ 6�   #��[ 6�   G 6E   �� *menu.menuListsSelectedItem[4]+��6�   �� *menu.menuItemsLists[4]+' 5�  &     5�  (   $( MouseUp��67   .) 5�  .     * 6D   �� *menu.addMenuItemICommand+5�  +   5�  %   5�     5�     5�     �� 5�     $
��MEAT��6   #��ZE 6,   #��ZF 6i   #��[
 6�   .��5�     �� -   5        $6 menuItemsMeatScroll��5�  '   ��.  $��Hidden=�6]   $��Hidden=�6�   .��5�     �� $ Vertical=�6)   ' 5�  $     5�  &   $( 	MouseMove��65   .) 5�  (     * 6>   �� *menu.mouseMoveMenuICommand+9 5�  *   `� 5�  ,   #: [  69   .1�5�  .   ��  66   �� *FindAncestor+$ ScrollViewerL��� 5�  .    66   �� *FindAncestor+$ 
StackPanelL�5�  -   5�  )   5�  '   .+�5�  $   �� -   5        $; menuItemsMeat��5�  ,   $��0q�6z   #��[ 6�   #��[ 6�   G 6C   �� *menu.menuListsSelectedItem[5]+��6�   �� *menu.menuItemsLists[5]+' 5�  (     5�  *   $( MouseUp��69   .) 5�  .     * 6D   �� *menu.addMenuItemICommand+5�  +   5�  %   5�     5�     5�     �� 5�     $
��KIDS��6   #��ZE 6,   #��ZF 6i   #��[
 6�   .��5�     �� -   5        $6 menuItemsKidsScroll��5�  '   ��.  $��Hidden=�6]   $��Hidden=�6�   .��5�     �� $ Vertical=�6)   ' 5�  "     5�  $   $( 	MouseMove��63   .) 5�  &     * 6<   �� *menu.mouseMoveMenuICommand+9 5�  (   `� 5�  *   #: [  67   .1�5�  ,   ��  64   �� *FindAncestor+$ ScrollViewerL��� 5�  ,    64   �� *FindAncestor+$ 
StackPanelL�5�  +   5�  '   5�  %   .+�5�  "   �� -   5        $; menuItemsKids��5�  *   $��0q�6x   #��[ 6�   #��[ 6�   G 6A   �� *menu.menuListsSelectedItem[6]+��6�   �� *menu.menuItemsLists[6]+' 5�  &     5�  (   $( MouseUp��67   .) 5�  .     * 6D   �� *menu.addMenuItemICommand+5�  +   5�  #   5�     5�     5�     5�     5�     5�     � 5�  
   -   5        $ transparentGrayOverlay��5�     #��Z 6f   #��Z 6�   y�6/   �� $  order.takeOrderGrayOverlay�.+�5�     �� 
�������H J� Opacity$	H 0.8Q�6(   � 5�     -   5        $ dialogBackground��5�     I   getDialogBoxHeight#��ZI 6-   J   getDialogBoxWidth#��ZJ 6g   .+�5�     � -   5        $ dialogBtnText��5�     
��� E��!K   getDialogBoxTextAreaHeight#��ZK 6E    L   getDialogBoxTextAreaWidth#��ZL 6�   $	��Top=�6�   .+�5�     �� $��Confirm this order?��6    $��28(�6;   $��Courier)�6I   
�������$��Center=�6q   $��Center=�6�   5�     � 5�     -   5        $ dialogBtnAccept��5�     
��� E�� M   getDialogBoxBtnAreaHeight#��ZM 6G   N   getDialogBoxBtnAreaWidth#��ZN 6�   $��Bottom=�6�   $
��Left=�6�   .+�5�     �� 
�������$��2q�61   #��ZM 6E   #��ZN 6�   �� 5�     $��Accept��6    $��24(�6.   $��Courier)�6<   
�������$��Center=�6d   $��Center=�6�   ' 5�       5�     $( PreviewMouseUp��6)   .) 5�       * 64   �� *order.dialogBoxAcceptICommand+5�     5�     � 5�     -   5        $ dialogBtnReject��5�     
��� E��#��ZM 6G   #��ZN 6�   $��Bottom=�6�   $��Right=�6�   .+�5�     �� 
�������$��2q�61   #��ZM 6E   #��ZN 6�   �� 5�     $��Reject��6    $��24(�6.   $��Courier)�6<   
�������$��Center=�6d   $��Center=�6�   ' 5�       5�     $( PreviewMouseUp��6)   .) 5�       * 64   �� *order.dialogBoxRejectICommand+5�     5�     5�     �� 5�     
�������$��2q�6)   #��ZI 6=   #��ZJ 6w   5�     5�     5�     