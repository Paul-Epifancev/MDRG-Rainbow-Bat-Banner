do
    
    local function ChangeRainbowBat(value, item_bat_rainbow)
        if item_bat_rainbow.IsEquipped() and value then
            TextureOverriderManager.RoomManager.SetSprite("/Room/BatBanner", batRainbowAsset)
        else            
            TextureOverriderManager.RoomManager.RestoreSprite("/Room/BatBanner", batRainbowAsset)
        end
    end  

    local itemprefab_bat_rainbow = ModUtilities.CreateItemPrefab()
    itemprefab_bat_rainbow.Name = '<color=#FF0000>R</color><color=#FF7F00>a</color><color=#FFE600>i</color><color=#00FF00>n</color><color=#00E5FF>b</color><color=#0044FF>o</color><color=#9900FF>w</color> <color=#99FF00>Bat Banner</color>'
    itemprefab_bat_rainbow.Description = '<color=#00E5FF>Animated cyber-banner</color> with <color=#FF007F>HSV rainbow cycling</color>'
    itemprefab_bat_rainbow.Price = 0
    itemprefab_bat_rainbow.PossibleEquipmentSlots = {'Room_bat_rainbow'}
    itemprefab_bat_rainbow.IsIllegal = false
    itemprefab_bat_rainbow.HasQuality = false
    itemprefab_bat_rainbow.IsStackable = false
    itemprefab_bat_rainbow.Category = ItemCategory.Room
    itemprefab_bat_rainbow.CanChangeColor = false
    itemprefab_bat_rainbow.ColorSlots = {}
    itemprefab_bat_rainbow.ScratchType = ScratchTextureType.Universal
    itemprefab_bat_rainbow.SusModifiers = {}
    itemprefab_bat_rainbow.SpecialEffectAction = ChangeRainbowBat
	batRainbowAsset = ModUtilities.GetSpriteReference(CurrentModGuid, "RainbowBatBanner.png")

    local item_bat_rainbow_obj = ModUtilities.CreateNewItemAutoAssignId(CurrentModGuid, itemprefab_bat_rainbow)
    ModUtilities.AddGenericItemToShop('clothier', item_bat_rainbow_obj)
end
