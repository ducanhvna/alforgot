function ChatAgent(name)
{
    this.Name = name;

}

ChatAgent.prototype.connection = function(socket){
    console.log('a user connected');
    socket.broadcast.emit('hi');
    socket.on('disconnect',function(){
        console.log('User disconnect')
    });
    socket.on('chat message',function(msg){
        console.log('message: '+msg);
        io.emit('chat message', msg);
    });
}

ChatAgent.prototype.disconnect = function(){
    console.log('User disconnect')
}

module.exports = ChatAgent;