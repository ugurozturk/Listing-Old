(function ($) {
    $.fn.jtablelistload = function (username, listtype, liststatus, title, ownuser) {
        
       if( ownuser == 1) {
            this.jtable({
                title: title,
                selecting: true, //Enable selecting
                multiselect: false, //Allow multiple selecting
                selectingCheckboxes: true,
                actions: {
                    listAction: '/EvrenselKodlar/readuserlist?userr=' + username + '&listtype=' + listtype + '&liststatus=' + liststatus,
                    updateAction: '/EvrenselKodlar/updateuserlist'
                },
                fields: {
                    user_list_id: {
                        key: true,
                        list: false,
                        edit: false,
                    },
                    name: {
                        edit:false,
                        title: 'names',
                        width:'auto'
                    },
                    score: {
                        title: 'Score',
                        width: '70px',
                        edit: true
                    },
                    episode_complete: {
                        title: 'Episode Complete',
                        width: '150px',
                        edit: true
                    },
                    user_tags: {
                        edit: true,
                        title: 'tags',
                        width: '150px',
                    },
                    list_type_id:{
                        edit: false,
                        list: false,
                        create:false,
                    },
                    list_status_id: {
                        edit: true,
                        dependsOn: 'list_type_id',
                        list: false,
                        title: 'statu',
                        options: function (data) {
                            return '/EvrenselKodlar/jtabbaglistatusgetir?listTypes=' + data.record.list_type_id;
                        }
                    }

                },
            });
       } else if (ownuser == 0) {
           this.jtable({
               title: title,
               selecting: true, //Enable selecting
               multiselect: false, //Allow multiple selecting
               selectingCheckboxes: true,
               actions: {
                   listAction: '/EvrenselKodlar/readuserlist?userr=' + username + '&listtype=' + listtype + '&liststatus=' + liststatus
               },
               fields: {
                   user_list_id: {
                       key: true,
                       list: false,
                       edit: false,
                   },
                   name: {
                       edit: false,
                       title: 'names',
                       width: 'auto'
                   },
                   score: {
                       title: 'Score',
                       width: '70px',
                       edit: true
                   },
                   episode_complete: {
                       title: 'Episode Complete',
                       width: '150px',
                       edit: true
                   },
                   user_tags: {
                       edit: true,
                       title: 'tags',
                       width: '150px',
                   },
                   list_type_id: {
                       edit: false,
                       list: false,
                       create: false,
                   },
                   list_status_id: {
                       edit: true,
                       dependsOn: 'list_type_id',
                       list: false,
                       title: 'statu',
                       options: function (data) {
                           return '/EvrenselKodlar/jtabbaglistatusgetir?listTypes=' + data.record.list_type_id;
                       }
                   }

               },
           });
       }
            this.jtable('load');

			return false;
        };
   
}(jQuery));