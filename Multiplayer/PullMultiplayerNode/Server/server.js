var io = require('socket.io').listen(4545);

var people = {};
var createRoom = function(client,room){
    if(people[room] == undefined)
       people[room] = {};
}

io.on('connection', function(socket){
        console.log('connect');
        //socket.emit('connect'); 
        //socket.broadcast.emit('connect_broadcast','connect_broadcast');
        socket.on("join", function(data){
            socket.join(data.room);  
            socket.room = data.room; 
            console.log("connected ",data.name," - ",data.room);
            createRoom(socket,socket.room);
            
            people[socket.room][socket.id] = data.name;
            console.log('Rooms:',people);
            
            socket.emit('join',data);
            socket.broadcast.emit('join_broadcast',data); 
        });
        socket.on('login', function(a){
           console.log('login');
           socket.emit('login','login');
        });
        socket.on('msg', function(a){
           socket.emit('msg',a);
        });
        socket.on('move', function(a){
           socket.emit('move',a);
           socket.broadcast.emit('move_broadcast',a);
        });
        socket.on('disconnect',function(){
           console.log('disconnect');
           socket.emit('disconnect');
           //socket.broadcast.emit('disconnect_broadcast');
        });
})
