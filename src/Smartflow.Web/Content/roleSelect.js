﻿/********************************************************************
 License: https://github.com/chengderen/Smartflow/blob/master/LICENSE 
 Home page: https://www.smartflow-sharp.com
 ********************************************************************
 */
;(function () {

    function loadGroup(nx) {
        var ajaxSettings = { url: 'api/setting/GetGroup', type: 'get' };
        ajaxSettings.data = ajaxSettings.data || {};

        ajaxSettings.success = function (serverData) {

            var leftDataSource = [], rightDataSource = [];

            $.each(serverData, function () {
                leftDataSource.push({
                    value: this.ID,
                    title: this.Name,
                    disabled: '',
                    checked: ''
                });
            });
            
            $.each(nx.group, function () {
                rightDataSource.push(this.id);
            });

            var transfer = layui.transfer;

            //基础效果
            transfer.render({
                elem: '#transfer'
                , title: ['待选择', '已选择']
                , data: leftDataSource
                , value: rightDataSource
                , height: 495
                , width: 322
                , id: 'rightGroup'
            });
        };

        util.ajaxService(ajaxSettings);
    }

    function setGroup(nx) {

        var transfer = layui.transfer,
            rightData = transfer.getData('rightGroup');

        var roleArray = [];

        $(rightData).each(function () {
            var self = this;
            roleArray.push({
                id: self.value,
                name: self.title
            });
        });

        nx.group = roleArray;
    }

    window.setting = {
        load: loadGroup,
        set: setGroup
    };

})();