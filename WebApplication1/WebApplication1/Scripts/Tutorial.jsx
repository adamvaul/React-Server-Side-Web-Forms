﻿
var CommentBox = React.createClass({
    loadCommentsFromServer: function() {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function() {
            var data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        }.bind(this);
        xhr.send();
    },
    handleCommentSubmit: function(comment) {
        var self = this;
        //var data = {};
        //data.Author = comment.Author;
        //data.append('Text', comment.Text);

        var xhr = new XMLHttpRequest();
        xhr.open('post', this.props.submitUrl, true);
        xhr.setRequestHeader("Content-type","text/json");
        xhr.onload = function() {
            var data = JSON.parse(this.responseText);
            //console.log(data);
            self.setState({ data: data });
            //self.loadCommentsFromServer();
        };
        xhr.send(JSON.stringify(comment));
    },
    getInitialState: function() {
        return {data: this.props.initialData};
    },
    componentDidMount: function() {
		console.log('mounted');
        //this.loadCommentsFromServer();
        //window.setInterval(this.loadCommentsFromServer, this.props.pollInterval);
    },
    render: function() {
        return (
          <div className="commentBox">
            <h1>Comments</h1>
            <CommentList data={this.state.data} />
            <CommentForm onCommentSubmit={this.handleCommentSubmit} />
          </div>
      );
    }
});

var CommentList = React.createClass({
    render: function() {
        var commentNodes = this.props.data.map(function (comment, i) {
            return (
                <Comment key={i} author={comment.Author}>
                    {comment.Text}
                </Comment>
                );
        });
        return (
          <div className="commentList">
            {commentNodes}
          </div>
        );
     }
});

var Comment = React.createClass({
    render: function() {
        return (
          <div className="comment">
            <h2 className="commentAuthor">
              {this.props.author}
            </h2>
        {this.props.children}
        </div>
      );
    }
});

var CommentForm = React.createClass({
    handleSubmit: function(e) {
		console.log('hello world');
        e.preventDefault();
        var author = this.refs.author.getDOMNode().value.trim();
        var text = this.refs.text.getDOMNode().value.trim();
        if (!text || !author) {
            return;
        }
        this.props.onCommentSubmit({Author: author, Text: text});
        this.refs.author.getDOMNode().value = '';
        this.refs.text.getDOMNode().value = '';
		return false;
    },
    render: function() {
		console.log('rendering comment form');
        return (
			<form className="commentForm" onSubmit={this.handleSubmit}>
				<input type="text" placeholder="Your name" ref="author" />
				<input type="text" placeholder="Say something..." ref="text" />
				<input type="submit" value="Post" />
			</form>
		);
	}
});

//var data = [
//  { Author: "Daniel Lo Nigro", Text: "Hello ReactJS.NET World!" },
//  { Author: "Pete Hunt", Text: "This is one comment" },
//  { Author: "Jordan Walke", Text: "This is *another* comment" }
//];


//React.render(
//  <CommentBox url="api/Home" submitUrl="api/Home/addcomment" pollInterval={2000} />,
//  document.getElementById('content')
//);