var io = require('socket.io')({
	transports: ['websocket'],
});

io.attach(4567);

io.on('connection', function(socket){
        console.log('connect');
        socket.emit('connect','connect'); 

	socket.on('beep', function(){
                console.log('beep');
		socket.emit('boop');
	});
        socket.on('msg', function(a){
                console.log('beep',a);
                socket.emit('boop',a);
        });
})
