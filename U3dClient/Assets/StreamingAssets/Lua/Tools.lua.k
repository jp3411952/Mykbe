---@type Tools
local Tools = {}

function Tools.SetButton (button, func)
    if button and button.onClick then
        button.onClick:RemoveAllListeners()
        button.onClick:AddListener(func)
    else
        print("set event faild ,not button")
    end
end

return Tools
